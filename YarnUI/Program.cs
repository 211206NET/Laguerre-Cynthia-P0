using UI;
using Serilog;

//temporarily adding it to a my computer

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("../YarnDL/LoggingInfo.txt")
    .CreateLogger();
MenuFactory.GetMenu("mainy").Start();


