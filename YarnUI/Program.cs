using UI;
using Serilog;

//temporarily adding it to a my computer

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(@"C:\Users\cynth\OneDrive\Documents\Revature\P0FileLog.log")
    .CreateLogger();
MenuFactory.GetMenu("mainy").Start();


