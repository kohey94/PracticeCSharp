﻿# メモ
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
###  ConfigureServices
アプリケーションで使用されるサービスをDIコンテナに追加する。  
ConfigureServicesが定義されている場合は、Configureより先に呼び出される。  
###  Configure
HTTPリクエストパイプラインを構成する。  
必ず呼び出される。