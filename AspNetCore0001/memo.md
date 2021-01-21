# メモ
## Program.cs
ASP.NET Coreアプリケーションはdotnet.exeによって呼び出されるコンソールアプリケーションにすぎない。  
Program.csがそのコンソールアプリケーションのソースコード。  
Webサーバー（IIS）に送信されてきたリクエストをコンソールアプリケーションに転送  
↓  
HTTPモジュールにより、IISのプロセス空間からプログラムが実行される。  
ApacheやNginxなどの他のWebサーバーでASP.NET Coreアプリケーションをホストするには、同じような拡張モジュールが必要になる。  

## Startup.cs
アプリケーションに送信されたリクエストは全てリクエストパイプラインで処理される。  
Startup.csにはリクエストパイプラインを構成するためのクラスが含まれる。  
このクラスには、アプリケーションの初期化時にホストがコールバックするメソッドが少なくとも2つ定義されている。  
ConfigureServicesとConfigureはリフレクションで呼び出される。  
環境変数によって複数のStartup.csを使い分けることができる（その場合、Program.csの記述はwebBuilder.UseStartup(Assembly.GetEntryAssembly().GetName().Name);となる）。  
StartupDevelopment.cs、StartupProduction.csなど。  
###  ConfigureServices
アプリケーションで使用されるサービスをDIコンテナに追加する。  
ConfigureServicesが定義されている場合は、Configureより先に呼び出される。  
環境変数によって複数のConfigureServicesを使い分けることができる。  
ConfigureDevelopmentServices、ConfigureProductionServicesなど。  
###  Configure
HTTPリクエストパイプラインを構成する。  
必ず呼び出される。  
環境変数によって複数のConfigureを使い分けることができる。  
ConfigureDevelopment、ConfigureProductionなど。  
IWebHostEnvironmentの拡張メソッドでも環境ごとの処理を分けることができる。  
IWebHostEnvironment.IsDevelopment()、IWebHostEnvironment.IsProduction()など。  
