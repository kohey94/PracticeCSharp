# ASP.NET Core MVCメモ
## AddMvcCoreとAddMvc
AddMvcCoreは最小限のMVCサービスを追加する。AddMvcは全てのMVCサービスを追加する。  
参考:https://qiita.com/sengoku/items/6c30d1de09a62e28348f  

## UseMvc
MVCサービスを追加したらUseMvcを使い、ルーティングを有効化する。  
UseMvcWithDefaultRouteでデフォルトのルートを設定できる。  
UseMvcにパラメーターを渡さなくてもアプリケーションは起動するが、ルートの設定がされていないため404エラーになる。  
