using System.ComponentModel;

public enum EIdLine : int
{
    [Description("ROCKER DERECHO")]
    RKRRH     = 4,
    [Description("ROCKER IZQUIERDO")]
    RKRLH     = 5,
    [Description("UPPER RIEL LH")]
    UPRRAILLH = 8,
    [Description("UPPER RIEL RH")]
    UPRRAILRH = 7,
    [Description("BARRA 4 UPPER")]
    BAR4UPR   = 12,
    [Description("BARRA 4 LOWER")]
    BAR4LWR   = 11,
    [Description("WHEEL HOUSE DERECHO")]
    WHRH      = 18,
    [Description("SKIES")]
    SKIES     = 13,
    [Description("BIG H")]
    BIGH      = 3,
    [Description("BARRA 5")]
    BAR5      = 6,
    [Description("BARRA 2")]
    BAR2      = 9,
    [Description("WHEEL HOUSE IZQUIERDO")]
    WHLH      = 19,
    [Description("CAJA IZQUIERDA")]
    BOXLH     = 16,
    [Description("BARRA 3")]
    BAR3      = 10,
    [Description("CAJA DERECHA")]
    BOXRH     = 17,
    [Description("PANEL 5")]
    PANEL5    = 20,
    [Description("RIEL IZQUIERDO")]
    RRLH      = 14,
    [Description("RIEL DERECHO")]
    RRRH      = 15,
    [Description("CELDAS MIG")]
    CELDASMIG = 22,
}

public enum ETypes
{
    [Description("MANTENIMIENTO")]
    MTO = 1,
    [Description("CALIDAD")]
    CAL = 2,
    [Description("MATERIALES")]
    MLE = 3,
    [Description("PERSONAL DE ZONA")]
    PDZ = 4,
    [Description("ADVERTENCIA!")]
    ADV = 5,
    [Description("PRODUCCION")]
    PRO = 6,
    [Description("COMPLETO!")]
    COM = 7,
    [Description("SEGURIDAD")]
    SEG = 8,
    [Description("SUPERMARKET")]
    SMK = 9,
    [Description("SISTEMAS")]
    SIS = 10,
    [Description("WARNING!")]
    WAR = 11,
    [Description("PARO DE LINEA!")]
    PDL = 12
}

public enum EApps
{
    [Description("PRODUCCION")]
    PRODUCCION = 1,
    [Description("VISOR GENERAL")]
    VISORGEN = 2,
    [Description("TEST ANDON")]
    TEST = 3,
    [Description("MATERIALES")]
    MATERIALES = 4,
    [Description("ANDON TRACKER")]
    ANDTRACKER = 5,
    [Description("ADMINISTRADOR")]
    ADMON = 6,
    [Description("SUPERMERCADO")]
    SUPERMARKET = 7,
    [Description("PANELGROUP")]
    PANELGROUP = 8
}
