namespace CurrencyConverter.Domain;

/// <summary>
/// ISO 4217 
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Currency
{
    None = 0,

    [Description("Saudi riyal, Saudi Arabia")]
    SAR = 682,

    [Description("UAE Dirham, United Arab Emirates")]
    AED = 784,

    [Description("Pound sterling, United Kingdom")]
    GBP = 826,

    [Description("Kuwaiti dinar, Kuwait")]
    KWD = 414,

    [Description("Bahraini dinar, Bahrain")]
    BHD = 048,

    [Description("Omani rial, Oman")]
    OMR = 512,

    [Description("Euro, European Community")]
    EUR = 978,

    [Description("Dollar, United States")]
    USD = 840,

    [Description("Afghani, Afghanistan")]
    AFN = 971,

    [Description("Lek, Albania")]
    ALL = 8,

    [Description("Armenian Dram, Armenia")]
    AMD = 51,

    [Description("Argentine Peso, Argentina")]
    ARS = 32,

    [Description("Australian Dollar, United States")]
    AUD = 36,

    [Description("Azerbaijanian Manat, Azerbaijan")]
    AZN = 944,

    [Description("Convertible Mark, Bosnia and Herzegovina")]
    BAM = 977,

    [Description("Taka, Bangladesh")]
    BDT = 50,

    [Description("Bulgarian Lev, Bulgaria")]
    BGN = 975,

    [Description("Brunei Dollar, Brunei")]
    BND = 96,

    [Description("Boliviano, Bolivia")]
    BOB = 68,

    [Description("Brazilian Real, Brazil")]
    BRL = 986,

    [Description("Belize Dollar, Belize")]
    BZD = 84,

    [Description("Canadian Dollar, Canada")]
    CAD = 124,

    [Description("Swiss Franc, Switzerland")]
    CHF = 756,

    [Description("Chilean Peso, Chile")]
    CLP = 152,

    [Description("Yuan Renminbi, China")]
    CNY = 156,

    [Description("Colombian Peso, Columbia")]
    COP = 170,

    [Description("Costa Rican Colon, Costa Rica")]
    CRC = 188,

    [Description("Czech Koruna, Czech Republic")]
    CZK = 203,

    [Description("Danish Krone, Denmark")]
    DKK = 208,

    [Description("Dominican Peso, Dominican Republic")]
    DOP = 214,

    [Description("Algerian Dinar, Algeria")]
    DZD = 12,

    [Description("Egyptian Pound, Egypt")]
    EGP = 818,

    [Description("Ethiopian Birr, Ethiopia")]
    ETB = 230,

    [Description("Lari, Georgia")]
    GEL = 981,

    [Description("Quetzal, Guatemala")]
    GTQ = 320,

    [Description("Hong Kong Dollar, Hong Kong")]
    HKD = 344,

    [Description("Lempira, Honduras")]
    HNL = 340,

    [Description("Kuna, Croatia")]
    HRK = 191,

    [Description("Forint, Hungary")]
    HUF = 348,

    [Description("Rupiah, Indonesia")]
    IDR = 360,

    [Description("Indian Rupee, India")]
    ILS = 376,

    [Description("Dollar, United States")]
    INR = 356,

    [Description("Iraqi Dinar, Iraq")]
    IQD = 368,

    [Description("Iranian Rial, Iran")]
    IRR = 364,

    [Description("Jamaican Dollar, Jamaica")]
    JMD = 388,

    [Description("Jordanian Dinar, Jordan")]
    JOD = 400,

    [Description("Yen, Japan")]
    JPY = 392,

    [Description("Kenyan Shilling, Kenya")]
    KES = 404,

    [Description("Som, Kyrgyzstan")]
    KGS = 417,

    [Description("Riel, Cambodia")]
    KHR = 116,

    [Description("Won, South Korea")]
    KRW = 410,

    [Description("Tenge, Kazakhstan")]
    KZT = 398,

    [Description("Lebanese Pound, Lebanon")]
    LBP = 422,

    [Description("Sri Lankan Rupee, Sri Lanka")]
    LKR = 144,

    [Description("Libyan Dinar, Libya")]
    LYD = 434,

    [Description("Moroccan Dirham, Morocco")]
    MAD = 504,

    [Description("Denar, North Macedonia")]
    MKD = 807,

    [Description("Tugrik, Mongolia")]
    MNT = 496,

    [Description("Pataca, Macao")]
    MOP = 446,

    [Description("Rufiyaa, Maldives")]
    MVR = 462,

    [Description("Mexican Peso, Mexico")]
    MXN = 484,

    [Description("Malaysian Ringgit, Malaysia")]
    MYR = 458,

    [Description("Cordoba Oro, Nicaragua")]
    NIO = 558,

    [Description("Norwegian Krone, Norway")]
    NOK = 578,

    [Description("Nepalese Rupee, Nepal")]
    NPR = 524,

    [Description("New Zealand Dollar, New Zealand")]
    NZD = 554,

    [Description("Balboa, Panama")]
    PAB = 590,

    [Description("Nuevo Sol, Peru")]
    PEN = 604,

    [Description("Philippine Peso, Philippines")]
    PHP = 608,

    [Description("Pakistan Rupee, Pakistan")]
    PKR = 586,

    [Description("Zloty, Poland")]
    PLN = 985,

    [Description("Guarani, Paraguay")]
    PYG = 600,

    [Description("Qatari Rial, Qatar")]
    QAR = 634,

    [Description("Romanian Leu, Romania")]
    RON = 946,

    [Description("Serbian Dinar, Serbia")]
    RSD = 941,

    [Description("Russian Ruble, Russia")]
    RUB = 643,

    [Description("Rwanda Franc, Rwanda")]
    RWF = 646,

    [Description("Swedish Krona, Sweden")]
    SEK = 752,

    [Description("Singapore Dollar, Singapore")]
    SGD = 702,

    [Description("Syrian Pound, Syria")]
    SYP = 760,

    [Description("Baht, Thailand")]
    THB = 764,

    [Description("Tunisian Dinar, Tunisia")]
    TND = 788,

    [Description("Turkish Lira, Turkey")]
    TRY = 949,

    [Description("Trinidad and Tobago Dollar, Trinidad and Tobago")]
    TTD = 780,

    [Description("New Taiwan Dollar, Taiwan")]
    TWD = 901,

    [Description("Dollar, United States")]
    UAH = 980,

    [Description("Peso Uruguayo, Uruguay")]
    UYU = 858,

    [Description("Sum, Uzbekistan")]
    UZS = 860,

    [Description("Bolivar, Venezuela")]
    VEF = 937,

    [Description("Dong, Vietnam")]
    VND = 704,

    [Description("Yemeni Rial, Yemen")]
    YER = 886,

    [Description("Rand, South Africa")]
    ZAR = 710,

    [Description("Botswana pula, Botswana")]
    BWP = 072,

    [Description("Ghanaian cedi, Ghana")]
    GHS = 936,

    [Description("Zambian Kwacha, Zambia")]
    ZMW = 967
}
