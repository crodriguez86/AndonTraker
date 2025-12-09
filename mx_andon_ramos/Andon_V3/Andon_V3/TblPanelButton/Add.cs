using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.TblPanelButton
{
    public partial class Add : Form
    {
        public int id = -1;
        public int idPanel = -1;
        public bool update = false;
        public bool towerActive = false;
        public Add()
        {
            InitializeComponent();
        }
        public class ComboboxItem
        {
            public int ID { get; set; }
            public string Name { get; set; }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
                var obj2 = objBLL.GetById(id);

                if (string.IsNullOrEmpty(txtName.Text))
                    throw new Exception("Name required.");

                AndonPanelButton obj = new AndonPanelButton();
                obj.ButtonName = txtName.Text.Trim();
                int.TryParse(cmbMsg.SelectedValue?.ToString(), out int idMsg);
                if (idMsg == 0)
                    throw new Exception("Please select a message from combo box.");

                int.TryParse(cmbColumn.SelectedValue?.ToString(), out int column);
                if (column == -1)
                    throw new Exception("Please select a message from combo box.");

                int.TryParse(cmbRow.SelectedValue?.ToString(), out int row);
                if (row == -1)
                    throw new Exception("Please select a message from combo box.");

                obj.ButtonColumn = column;
                obj.ButtonRow = row;
                obj.ButtonState = chkState.Checked;
                obj.IdPanel = idPanel;
                obj.IsBinary = objBLL.MsgIsBinary(idMsg);
                obj.IdMsg = idMsg;
                obj.IdButton = id;
                obj.ButtonTowerConfig = Convert.ToInt16(cmbTowerConfig.SelectedValue);
                obj.ButtonTowerIp = obj.ButtonTowerConfig == 1 ? "" : txtTowerIp.Text;
                obj.ButtonTowerCommand = txtTowerCmd.Text;
                obj.ButtonTowerCommand2 = txtTowerCmd2.Text;
                if (update)
                {
                    if (obj.ButtonColumn != obj2.ButtonColumn || obj.ButtonRow != obj2.ButtonRow)
                    {
                        //Si la columna o fila con diferentes a las guardadas en bd. Valida que no esten repetidas
                        if (objBLL.CheckColumnRowByPanel(idPanel, obj.ButtonColumn ?? 0, obj.ButtonRow ?? 0))
                            throw new Exception("Selected 'column' and 'row' are already in use. Please select others.");
                    }
                    if (obj.IdMsg != obj2.IdMsg)
                    {
                        //Si el id del mensaje es diferente al de bd, valida que no este repetidos
                        if (objBLL.CheckIdMsgByPanel(idPanel, idMsg))
                            throw new Exception("Message is already set in this panel.");
                    }
                    
                    if (obj.IsBinary == true)//Solo los nombres de botones binarios nos aseguramos que sean unicos
                    {
                        if (obj.ButtonName != obj2.ButtonName)
                        {
                            //Si el mensaje es diferente al de bd, valida que no este repetido
                            var obj3 = objBLL.GetButtonNameByPanel(idPanel, obj.ButtonName);
                            if (obj3 != null)
                                throw new Exception("The button name is already set in this panel.");
                        }
                    }
                    bool valid = objBLL.Update(obj);
                    if (valid)
                        MreaMessage.ShowOK("Panel button updated successfully ID: (" + id + ")");
                    else
                        MreaMessage.ShowWarning("Panel button not updated. Something went wrong. " + objBLL._error);
                    this.Close();
                }
                else
                {
                    if (objBLL.CheckColumnRowByPanel(idPanel, obj.ButtonColumn ?? 0, obj.ButtonRow ?? 0))
                        throw new Exception("Selected 'column' and 'row' are already in use. Please select others.");

                    if (objBLL.CheckIdMsgByPanel(idPanel, idMsg))
                        throw new Exception("Message is already set in this panel.");

                    if (obj.IsBinary == true)//Solo los nombres de botones binarios nos aseguramos que sean unicos
                    {
                        var obj3 = objBLL.GetButtonNameByPanel(idPanel, obj.ButtonName);
                        if (obj3 != null)
                            throw new Exception("The button name is already set in this panel.");
                    }

                    int id = objBLL.Insert(obj);
                    if (id > 0)
                        MreaMessage.ShowOK("Panel button created successfully ID: (" + id + ")");
                    else
                        MreaMessage.ShowWarning("Panel button not created. Something went wrong. " + objBLL._error);
                }
            }
            catch (Exception ex)
            {
                MreaMessage.ShowWarning(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            SetVisibleTowerCommand(false);
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> listLines = andonBLL.getLines();
            List<AndonType> listTypes = andonBLL.getAndonTypes(new AndonType());
            AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
            AndonPanelViewBLL viewBLL = new AndonPanelViewBLL();
            AndonPanelGroupBLL groupBLL = new AndonPanelGroupBLL();
            List<Andon> list = buttonBLL.GetAllAndonMsgWithBinary();

            if (list == null)
            {
                MreaMessage.ShowWarning("Can't load messages from database. Something went wrong. " + buttonBLL._error);
            }
            else
            {
                if (listLines == null)
                {
                    MreaMessage.ShowWarning("Can't load lines from database. Something went wrong. ");
                }
                else
                {
                    if (listTypes == null)
                    {
                        MreaMessage.ShowWarning("Can't load types from database. Something went wrong. ");
                    }
                    else
                    {
                        listTypes.Insert(0, new AndonType { idType = 0, name = "ALL" });
                        listLines.Insert(0, new Andon { idLine = 0, nameLine = "ALL" });

                        cmbMsg.DataSource = list;
                        cmbMsg.DisplayMember = "nameText";
                        cmbMsg.ValueMember = "idMessage";

                        cmbType.DataSource = listTypes;
                        cmbType.DisplayMember = "name";
                        cmbType.ValueMember = "idType";
                        cmbLine.DataSource = listLines;
                        cmbLine.DisplayMember = "nameLine";
                        cmbLine.ValueMember = "idLine";


                        //cargar filas y columnas en base al panel
                        var objView = viewBLL.GetById(idPanel);
                        if (objView != null)
                        {

                            var objGroup = groupBLL.GetById(objView.IdGroup ?? 0);

                            if (objGroup != null)
                            {
                                if (objGroup.GroupTowerActive == true)
                                {
                                    //cargar combo con tipos de configuracion para la torreta
                                    var listConfig = new List<ComboboxItem>();
                                    listConfig.Add(new ComboboxItem { ID = 1, Name = "Use default IP" });
                                    listConfig.Add(new ComboboxItem { ID = 2, Name = "Use own IP" });
                                    listConfig.Add(new ComboboxItem { ID = 3, Name = "Use both IP" });
                                    cmbTowerConfig.DataSource = listConfig;
                                    cmbTowerConfig.DisplayMember = "Name";
                                    cmbTowerConfig.ValueMember = "ID";
                                    txtTowerIp.Text = buttonBLL.GetGlobalIpTower(this.idPanel);
                                    towerActive = true;
                                }
                            }

                            List<AndonPanelButton> listColumns = new List<AndonPanelButton>();
                            List<AndonPanelButton> listRows = new List<AndonPanelButton>();
                            for (int i = 0; i < objView.PanelColumns; i++)
                            {
                                listColumns.Add(new AndonPanelButton { IdButton = i, ButtonName = "Column " + i });
                            }
                            for (int i = 0; i < objView.PanelRows; i++)
                            {
                                listRows.Add(new AndonPanelButton { IdButton = i, ButtonName = "Column " + i });
                            }
                            cmbColumn.DataSource = listColumns;
                            cmbColumn.DisplayMember = "ButtonName";
                            cmbColumn.ValueMember = "IdButton";

                            cmbRow.DataSource = listRows;
                            cmbRow.DisplayMember = "ButtonName";
                            cmbRow.ValueMember = "IdButton";
                        }
                        else
                        {
                            MreaMessage.ShowWarning("Can't load panel view from database. Something went wrong. " + viewBLL._error);
                        }
                    }
                }
            }

            lblAction.Text = "INSERT";
            if (id > 0)
            {
                AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
                var obj = objBLL.GetById(id);
                if (obj != null)
                {
                    txtName.Text = obj.ButtonName;
                    cmbMsg.SelectedValue = obj.IdMsg;
                    cmbColumn.SelectedValue = Convert.ToInt32(obj.ButtonColumn);
                    cmbRow.SelectedValue = Convert.ToInt32(obj.ButtonRow);
                    chkState.Checked = obj.ButtonState ?? false;
                    if (towerActive)
                    {
                        SetVisibleTowerConfig(true);
                        cmbTowerConfig.SelectedValue = obj.ButtonTowerConfig == null ? 1 : (int)obj.ButtonTowerConfig;
                        cmbTowerConfig_SelectedIndexChanged(null,null);
                        txtTowerIp.Text = obj.ButtonTowerIp;
                        txtTowerCmd.Text = obj.ButtonTowerCommand;
                        txtTowerCmd2.Text = obj.ButtonTowerCommand2;
                    }
                    else
                    {
                        SetVisibleTowerConfig(false);
                    }
                    update = true;
                    lblAction.Text = "UPDATE";
                }
            }
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = cmbLine.SelectedValue?.ToString();
            string type = cmbType.SelectedValue?.ToString();
            if (int.TryParse(line, out int idLine) && int.TryParse(type, out int idType))
            {
                AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
                List<Andon> list = buttonBLL.GetAllAndonMsgWithBinary();

                if (list != null)
                {
                    if (idLine != 0 && idType != 0)
                    {
                        list = list.FindAll(l => l.idLine == idLine && l.idType == idType);
                    }
                    else if (idLine != 0)
                    {
                        list = list.FindAll(l => l.idLine == idLine);
                    }
                    else if (idType != 0)
                    {
                        list = list.FindAll(l => l.idType == idType);
                    }
                    cmbMsg.DataSource = list;
                    cmbMsg.DisplayMember = "nameText";
                    cmbMsg.ValueMember = "idMessage";
                }
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = cmbLine.SelectedValue?.ToString();
            string type = cmbType.SelectedValue?.ToString();
            if (int.TryParse(line, out int idLine) && int.TryParse(type, out int idType))
            {
                AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
                List<Andon> list = buttonBLL.GetAllAndonMsgWithBinary();

                if (list != null)
                {
                    if (idLine != 0 && idType != 0)
                    {
                        list = list.FindAll(l => l.idLine == idLine && l.idType == idType);
                    }
                    else if (idLine != 0)
                    {
                        list = list.FindAll(l => l.idLine == idLine);
                    }
                    else if (idType != 0)
                    {
                        list = list.FindAll(l => l.idType == idType);
                    }
                    cmbMsg.DataSource = list;
                    cmbMsg.DisplayMember = "nameText";
                    cmbMsg.ValueMember = "idMessage";
                }
            }
        }

        private void SetVisibleTowerCommand(bool visible)
        {
            lblTowerCmd2.Visible = visible;
            txtTowerCmd2.Visible = visible;
        }
        private void SetVisibleTowerConfig(bool visible)
        {
            lblTowerIp.Visible = visible;
            lblTowerConfig.Visible = visible;
            lblTowerCmd.Visible = visible;
            lblTowerCmd2.Visible = visible;
            txtTowerIp.Visible = visible;
            cmbTowerConfig.Visible = visible;
            txtTowerCmd.Visible = visible;
            txtTowerCmd2.Visible = visible;
        }

        private void cmbTowerConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
            string towerConfig = cmbTowerConfig.SelectedValue?.ToString();
            if (int.TryParse(towerConfig, out int idTowerConfig))
            {
                if (idTowerConfig == 1)//IP default
                {
                    //Consultar IP default y volver a colocarla en el text box
                    txtTowerIp.Text = buttonBLL.GetGlobalIpTower(this.idPanel);
                    //Hacer read only text box
                    txtTowerIp.ReadOnly = true;
                    SetVisibleTowerCommand(false);
                }else if (idTowerConfig == 2)//IP nueva
                {
                    //Quitar read only text box
                    txtTowerIp.ReadOnly = false;
                    SetVisibleTowerCommand(false);
                }else if (idTowerConfig == 3)//IP default y nueva
                {
                    //Quitar read only text box
                    txtTowerIp.ReadOnly = false;
                    SetVisibleTowerCommand(true);
                }
            }
        }
    }
}
