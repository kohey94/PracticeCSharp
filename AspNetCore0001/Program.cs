using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AspNetCore0001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // アプリケーションを実行するためのホストを作成する
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // UserStartupでStartup.csを指定する。
                    //webBuilder.UseStartup<Startup>();

                    // StartupXXXとマッチするパターンのStartup.csを利用する場合
                    // XXXはASPNETCORE_ENVIRONMENTの値とマッチする（プロジェクト>プロパティ>デバッグ）
                    webBuilder.UseStartup(Assembly.GetEntryAssembly().GetName().Name);
                    
                    //この中の拡張メソッドにより、色んな設定を追加できる。
                    // Kestrel使ったり、ContentRootの指定したり、etc
                });
    }
}
