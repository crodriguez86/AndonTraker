using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.Objects;
using MreaShared.BLL;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Andon_V3
{
    public partial class PanelView : Form
    {
        private static List<KeyValuePair<int, int>> _arrayIdTags = new List<KeyValuePair<int, int>>();
        private static List<KeyValuePair<int, int>> _arrayIdButtonActive = new List<KeyValuePair<int, int>>();
        public int _idPanel { get; set; }
        public int _rowCount { get; set; }
        public int _columnCount { get; set; }
        public bool _connected { get; set; }
        public string _towerIpDefault { get; set; }
        public string _towerClearCmd { get; set; }
        public bool _towerActive { get; set; }
        private List<AndonPanelButton> _buttonList = new List<AndonPanelButton>();

        public PanelView()
        {
            InitializeComponent();

            // OPTIMIZADO PARA 1366x768
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(320, 650); // Tamaño óptimo para 1366x768
            this.MinimumSize = new Size(280, 500);
            this.MaximumSize = new Size(400, 768);

            // Mejorar apariencia
            this.BackColor = Color.FromArgb(45, 45, 48); // Fondo oscuro moderno
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Suscribir al evento Resize
            this.Resize += PanelView_Resize;
        }

        private void PanelView_Load(object sender, EventArgs e)
        {
            try
            {
                // POSICIONAR EN EL LADO DERECHO DE LA PANTALLA
                PosicionarEnLadoDerecho();

                // Configurar estilos de controles
                ConfigurarEstilosControles();

                DBConnectionBLL objConn = new DBConnectionBLL();
                if (objConn.CheckConnection())
                {
                    _connected = true;
                    lblState.BackColor = Color.FromArgb(0, 123, 255); // Azul moderno
                    lblState.ForeColor = Color.White;
                    lblState.Text = "ONLINE " + DateTime.Now.ToString("HH:mm");
                    lblState.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    #region Table config - OPTIMIZADO PARA 1366x768

                    tablePanelView.ColumnCount = 1;
                    tablePanelView.RowCount = 0;
                    tablePanelView.ColumnStyles.Clear();
                    tablePanelView.RowStyles.Clear();
                    tablePanelView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                    tablePanelView.AutoSize = false;
                    tablePanelView.Dock = DockStyle.Fill;
                    tablePanelView.AutoScroll = false;
                    tablePanelView.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                    tablePanelView.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                    tablePanelView.Padding = new Padding(3);
                    tablePanelView.Margin = new Padding(2);
                    tablePanelView.BackColor = Color.FromArgb(37, 37, 38); // Fondo oscuro

                    #endregion

                    if (_idPanel != 0)
                    {
                        AndonPanelButtonBLL viewBLL = new AndonPanelButtonBLL();
                        AndonPanelViewBLL view2BLL = new AndonPanelViewBLL();
                        AndonPanelGroupBLL groupBLL = new AndonPanelGroupBLL();
                        AndonBLL andonBLL = new AndonBLL();

                        var objView = view2BLL.GetById(_idPanel);
                        if (objView != null)
                        {
                            lblPanelDesc.Text = objView.PanelName.ToUpper();
                            lblPanelDesc.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            lblPanelDesc.ForeColor = Color.White;

                            var objGroup = groupBLL.GetById(objView.IdGroup ?? 0);
                            if (objGroup != null)
                            {
                                if (objGroup.GroupTowerActive == true)
                                {
                                    lblPanelDesc.Text = objView.PanelName.ToUpper() + " • TOWER: " + objGroup.GroupTowerIp;
                                    _towerIpDefault = objGroup.GroupTowerIp;
                                    _towerClearCmd = objGroup.GroupTowerClearCommand;
                                    _towerActive = true;

                                    var listActiveButtons = viewBLL.GetAllActiveButtons(_idPanel);
                                    if (listActiveButtons == null)
                                        MakeAsyncRequest(_towerIpDefault + _towerClearCmd);
                                    else if (listActiveButtons.Count == 0)
                                        MakeAsyncRequest(_towerIpDefault + _towerClearCmd);
                                }
                                else
                                {
                                    lblPanelDesc.Text = objView.PanelName.ToUpper() + " • TOWER INACTIVE";
                                    _towerActive = false;
                                }
                            }
                        }

                        var list = viewBLL.GetAllByIdPanel(_idPanel);
                        _buttonList = list.ToList();

                        // Configurar las filas para distribución uniforme
                        ConfigurarFilasTableLayout();

                        foreach (var item in list)
                        {
                            AddIdTagToArray(item.IdTag ?? 0, item.IsBinary ?? false);
                            Button b = Create_Button(item);
                            if (item.ButtonState == true)
                            {
                                b.BackColor = Color.FromArgb(40, 167, 69); // Verde éxito
                                b.ForeColor = Color.White;
                                if (item.IsBinary == false)
                                {
                                    var newEntry = new KeyValuePair<int, int>(item.IdButton, 0);
                                    _arrayIdButtonActive.Add(newEntry);
                                }
                            }
                            tablePanelView.Controls.Add(b);
                        }

                        foreach (var item in _arrayIdTags)
                        {
                            andonBLL.setAndonValue(item.Key, 0);
                        }

                        // Ajustar distribución inicial
                        AjustarDistribucionVertical();

                        // Re-posicionar después de cargar el contenido
                        PosicionarEnLadoDerecho();
                    }
                    else
                    {
                        ShowWarning("Group ID is not valid");
                    }
                }
                else
                {
                    lblState.BackColor = Color.FromArgb(220, 53, 69); // Rojo error
                    lblState.ForeColor = Color.White;
                    lblState.Text = "OFFLINE " + DateTime.Now.ToString("HH:mm");
                    lblState.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    _connected = false;
                }
            }
            catch (Exception ex)
            {
                Application.Restart();
            }
        }

        private void ConfigurarEstilosControles()
        {
            // Estilo para lblTimeStateRunning
            lblTimeStateRunning.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblTimeStateRunning.ForeColor = Color.LightGray;

            // Estilo para lblStatusTower
           // lblStatusTower.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            //lblStatusTower.ForeColor = Color.LightGray;
        }

        private void ConfigurarFilasTableLayout()
        {
            if (_buttonList == null || _buttonList.Count == 0)
                return;

            tablePanelView.RowCount = _buttonList.Count;
            tablePanelView.RowStyles.Clear();

            // Configurar todas las filas con el mismo tamaño
            for (int i = 0; i < _buttonList.Count; i++)
            {
                tablePanelView.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _buttonList.Count));
            }
        }

        private void AjustarDistribucionVertical()
        {
            if (_buttonList == null || _buttonList.Count == 0)
                return;

            // Calcular altura disponible para botones (considerando otros controles)
            int alturaDisponible = this.ClientSize.Height - tablePanelView.Top - 80;

            if (alturaDisponible > 0 && _buttonList.Count > 0)
            {
                // Calcular altura por botón con límites razonables
                int alturaPorBoton = alturaDisponible / _buttonList.Count;
                alturaPorBoton = Math.Max(55, Math.Min(85, alturaPorBoton)); // Rango óptimo para 1366x768

                // Actualizar los estilos de fila
                tablePanelView.RowStyles.Clear();
                for (int i = 0; i < _buttonList.Count; i++)
                {
                    tablePanelView.RowStyles.Add(new RowStyle(SizeType.Absolute, alturaPorBoton));
                }

                // Forzar actualización del layout
                tablePanelView.PerformLayout();
            }
        }

        // MÉTODO PARA POSICIONAR EN EL LADO DERECHO - OPTIMIZADO PARA 1366x768
        private void PosicionarEnLadoDerecho()
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle workingArea = screen.WorkingArea;

            // Para 1366x768, posicionar en el lado derecho con margen
            int posX = workingArea.Right - this.Width - 5; // Pequeño margen del borde
            int posY = workingArea.Top + (workingArea.Height - this.Height) / 2;

            this.Location = new Point(posX, posY);
        }

        Button Create_Button(AndonPanelButton obj)
        {
            var b = new Button
            {
                Text = obj.NameType + "\n" + obj.ButtonName,
                Name = string.Format("btnView_{0}", obj.IdButton.ToString()),
                BackColor = Color.FromName(obj.BgName),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromName(obj.TxName),
                Height = 70, // Altura óptima para 1366x768
                Margin = new Padding(2, 4, 2, 4),
                Padding = new Padding(1),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            // Mejorar apariencia del botón
            b.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(Color.FromName(obj.BgName));
            b.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(Color.FromName(obj.BgName));

            b.Click += Event_Click;
            return b;
        }

        // Manejador del evento Resize
        private void PanelView_Resize(object sender, EventArgs e)
        {
            AjustarDistribucionVertical();
            AjustarFuenteSegunAncho();
        }

        private void AjustarFuenteSegunAncho()
        {
            int anchoActual = this.Width;
            float tamañoFuente = 9f; // Tamaño base óptimo para 1366x768

            // Ajuste fino para diferentes anchos
            if (anchoActual < 300)
            {
                tamañoFuente = 8f;
            }
            else if (anchoActual > 350)
            {
                tamañoFuente = 10f;
            }

            // Aplicar el tamaño de fuente a todos los botones
            foreach (Control control in tablePanelView.Controls)
            {
                if (control is Button button)
                {
                    button.Font = new Font("Segoe UI", tamañoFuente, FontStyle.Bold);
                }
            }
        }

        void Event_Click(object sender, EventArgs e)
        {
            if (_connected)
            {
                AndonValueBLL valueBLL = new AndonValueBLL();
                AndonBLL andonBLL = new AndonBLL();
                if (sender is Button b)
                {
                    string btnName = b.Name;
                    string idString = btnName.Split('_')[1];
                    int.TryParse(idString, out int idButton);
                    if (idButton != 0)
                    {
                        AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
                        var objButton = buttonBLL.GetByIdWithMsg(idButton);
                        if (objButton != null)
                        {
                            if (objButton.ButtonState == true)
                            {
                                if (objButton.IsBinary == true)
                                {
                                    buttonBLL.UpdateState(idButton, false);
                                    b.BackColor = Color.FromName(objButton.BgName);
                                    b.ForeColor = Color.FromName(objButton.TxName);
                                    var value = valueBLL.getAndonValues(new AndonValues { idAv = objButton.IdTag.Value });
                                    if (value != null)
                                    {
                                        int dAv = GetDecimalFromPosition(objButton.TagValue ?? 0);
                                        int av = value.First().andonValue ?? 0;
                                        if (av != 0)
                                        {
                                            int newAv = av - dAv;
                                            andonBLL.setAndonValue(objButton.IdTag.Value, newAv);
                                        }
                                    }
                                }
                                else
                                {
                                    AndonPinsBLL andonPinsBLL = new AndonPinsBLL();
                                    if (andonPinsBLL.CheckPinActiveByIdMsg(objButton.IdMsg ?? 0))
                                    {
                                        KeyPad key = new KeyPad();
                                        key._idMsg = objButton.IdMsg ?? 0;
                                        key._title = "END RESPONSE TIME";
                                        key._operator = false;
                                        key.FormClosed += new FormClosedEventHandler(KedPad_Closed);
                                        var screen = Screen.FromPoint(Cursor.Position);
                                        key.StartPosition = FormStartPosition.Manual;
                                        key.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - key.Width / 2;
                                        key.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - key.Height / 2;
                                        key.ShowDialog();

                                        buttonBLL.UpdateState(idButton, false);
                                        b.BackColor = Color.FromName(objButton.BgName);
                                        b.ForeColor = Color.FromName(objButton.TxName);
                                        if (objButton.ButtonTowerConfig == 2 || objButton.ButtonTowerConfig == 3)
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + _towerClearCmd);
                                        }

                                        KeyPad keyOp = new KeyPad();
                                        keyOp._idMsg = objButton.IdMsg ?? 0;
                                        keyOp._title = "END REPAIR TIME";
                                        keyOp._operator = true;
                                        keyOp._timeToWait = 20;
                                        keyOp.FormClosed += new FormClosedEventHandler(KedPad_Closed);
                                        var screenOP = Screen.FromPoint(Cursor.Position);
                                        keyOp.StartPosition = FormStartPosition.Manual;
                                        keyOp.Left = screenOP.Bounds.Left + screenOP.Bounds.Width / 2 - keyOp.Width / 2;
                                        keyOp.Top = screenOP.Bounds.Top + screenOP.Bounds.Height / 2 - keyOp.Height / 2;
                                        keyOp.ShowDialog();
                                        andonBLL.setAndonValue(objButton.IdTag ?? 0, 9999);
                                        Thread.Sleep(1500);
                                        andonBLL.setAndonValue(objButton.IdTag ?? 0, -1);
                                    }
                                    else
                                    {
                                        buttonBLL.UpdateState(idButton, false);
                                        b.BackColor = Color.FromName(objButton.BgName);
                                        b.ForeColor = Color.FromName(objButton.TxName);
                                        if (objButton.ButtonTowerConfig == 2 || objButton.ButtonTowerConfig == 3)
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + _towerClearCmd);
                                        }
                                    }
                                }
                            }
                            else if (objButton.ButtonState == false)
                            {
                                buttonBLL.UpdateState(idButton, true);
                                b.BackColor = Color.FromArgb(40, 167, 69); // Verde éxito
                                b.ForeColor = Color.White;
                                if (objButton.IsBinary == false)
                                {
                                    var newEntry = new KeyValuePair<int, int>(idButton, 0);
                                    _arrayIdButtonActive.Add(newEntry);
                                }
                                else if (objButton.IsBinary == true)
                                {
                                    var value = valueBLL.getAndonValues(new AndonValues { idAv = objButton.IdTag.Value });
                                    if (value != null)
                                    {
                                        int dAv = GetDecimalFromPosition(objButton.TagValue ?? 0);
                                        int av = value.First().andonValue ?? 0;
                                        int newAv = av + dAv;
                                        andonBLL.setAndonValue(objButton.IdTag.Value, newAv);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ShowWarning("SYSTEM OFFLINE - Please check connection");
            }
        }

        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddIdTagToArray(int idTag, bool binary)
        {
            if (!binary)
            {
                if (!CheckRepeatId(idTag, _arrayIdTags))
                {
                    var newEntry = new KeyValuePair<int, int>(idTag, 0);
                    _arrayIdTags.Add(newEntry);
                }
            }
        }

        private void AddIdButtonToArray(int idButton)
        {
            if (!CheckRepeatId(idButton, _arrayIdButtonActive))
            {
                var newEntry = new KeyValuePair<int, int>(idButton, 0);
                _arrayIdTags.Add(newEntry);
            }
        }

        private static bool CheckRepeatId(int id, List<KeyValuePair<int, int>> array)
        {
            bool repeat = false;
            if (id == 0)
                return repeat;
            if (array == null)
                return repeat;

            var foundId = array.Find(x => x.Key == id);

            if (foundId.Key != 0)
                return true;

            return repeat;
        }

        private void TimerCheckButtonState_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTimeStateRunning.Text = DateTime.Now.ToString("HH:mm:ss");
                DBConnectionBLL objConn = new DBConnectionBLL();
                if (objConn.CheckConnection())
                {
                    _connected = true;
                    lblState.BackColor = Color.FromArgb(0, 123, 255);
                    lblState.Text = "ONLINE " + DateTime.Now.ToString("HH:mm");
                    bool allSet = false;
                    var listUpdate = new List<KeyValuePair<int, int>>();
                    AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
                    AndonBLL andonBLL = new AndonBLL();
                    foreach (var item in _arrayIdButtonActive)
                    {
                        if (item.Value == 0)
                        {
                            allSet = false;
                            var objButton = buttonBLL.GetByIdWithMsg(item.Key);
                            if (objButton != null)
                            {
                                andonBLL.setAndonValue(objButton.IdTag ?? 0, objButton.TagValue ?? 0);
                                if (_towerActive)
                                {
                                    if (objButton.ButtonTowerConfig == 1)
                                    {
                                        MakeAsyncRequest(_towerIpDefault + objButton.ButtonTowerCommand);
                                    }
                                    else if (objButton.ButtonTowerConfig == 2)
                                    {
                                        if (objButton.ButtonState == true)
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + objButton.ButtonTowerCommand);
                                        }
                                        else
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + _towerClearCmd);
                                        }
                                    }
                                    else if (objButton.ButtonTowerConfig == 3)
                                    {
                                        if (objButton.ButtonState == true)
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + objButton.ButtonTowerCommand);
                                            MakeAsyncRequest(_towerIpDefault + objButton.ButtonTowerCommand2);
                                        }
                                        else
                                        {
                                            MakeAsyncRequest(objButton.ButtonTowerIp + _towerClearCmd);
                                            MakeAsyncRequest(_towerIpDefault + _towerClearCmd);
                                        }
                                    }
                                }
                                var newEntry = new KeyValuePair<int, int>(item.Key, 1);
                                listUpdate.Add(newEntry);
                                break;
                            }
                        }
                        else
                        {
                            allSet = true;
                        }
                    }
                    foreach (var item in listUpdate)
                    {
                        _arrayIdButtonActive.Remove(_arrayIdButtonActive.First(x => x.Key.Equals(item.Key)));
                        _arrayIdButtonActive.Add(item);
                    }
                    if (allSet)
                    {
                        _arrayIdButtonActive.Clear();
                        var listActiveButtons = buttonBLL.GetAllActiveButtons(_idPanel);
                        foreach (var item in listActiveButtons)
                        {
                            if (item.IsBinary == false)
                            {
                                _arrayIdButtonActive.Add(new KeyValuePair<int, int>(item.IdButton, 0));
                            }
                        }
                        if (_towerActive)
                        {
                            bool clear = false;
                            if (listActiveButtons == null)
                                clear = true;
                            else if (listActiveButtons.Count == 0)
                                clear = true;
                            if (clear)
                                MakeAsyncRequest(_towerIpDefault + _towerClearCmd);
                        }

                        foreach (var item in _arrayIdTags)
                        {
                            andonBLL.setAndonValue(item.Key, 0);
                        }
                    }
                }
                else
                {
                    lblState.BackColor = Color.FromArgb(220, 53, 69);
                    lblState.Text = "OFFLINE " + DateTime.Now.ToString("HH:mm");
                    _connected = false;
                }
            }
            catch (Exception ex)
            {
                Application.Restart();
            }
        }

        private int GetDecimalFromPosition(int position)
        {
            int decimalAndon = 1;

            for (int i = 1; i <= position; i++)
            {
                if (i == 1)
                {
                    decimalAndon = (decimalAndon * 1);
                }
                else
                {
                    decimalAndon = (decimalAndon * 2);
                }
            }

            return decimalAndon;
        }

        public Task<string> MakeAsyncRequest(string url)
        {
            lblStatusTower.Text = "Sending tower request: " + url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/html";
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 10000;
            request.Proxy = null;

            Task<WebResponse> task = Task.Factory.FromAsync(
                request.BeginGetResponse,
                asyncResult => request.EndGetResponse(asyncResult),
                (object)null);

            task.ContinueWith
            (t =>
            {
                if (t.Exception == null)
                {
                    return ReadStreamFromResponse(t.Result);
                }
                setlblStatusTowerText("Tower request failed: " + t.Exception.InnerException.Message);
                return null;
            }
            );
            return null;
        }

        private string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                setlblStatusTowerText("Tower response: " + strContent);
                return strContent;
            }
        }

        private void setlblStatusTowerText(string txt)
        {
            if (lblStatusTower.InvokeRequired)
            { lblStatusTower.Invoke(new Action(() => lblStatusTower.Text = txt)); return; }
            lblStatusTower.Text = txt;
        }

        void KedPad_Closed(object sender, FormClosedEventArgs e)
        {
            //
        }

        private void tablePanelView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}