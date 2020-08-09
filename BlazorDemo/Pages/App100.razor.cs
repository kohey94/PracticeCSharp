using System;
using System.Threading.Tasks;

namespace BlazorDemo.Pages
{
    public partial class App100
    {
        private TimeSpan タイマー = new TimeSpan();
        private bool タイマー起動中 = false;
        private async Task ストップウォッチ()
        {
            タイマー起動中 = true;
            while (タイマー起動中)
            {
                await Task.Delay(1000);
                if (タイマー起動中)
                {
                    タイマー = タイマー.Add(new TimeSpan(0, 0, 1));
                    StateHasChanged();
                }
            }
        }

        private string 入力文字列 { get; set; } = string.Empty;

        private string ランダム文字列 { get; set; } = string.Empty;

        private string 正誤判定 { get; set; } = string.Empty;

        private async void 文字列生成()
        {
            var 長さ = 20;
            var 半角英数字 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLNMOPQRSTUVWXYZ";

            var 生成文字列 = new System.Text.StringBuilder(長さ);
            var ランダム = new Random();

            for (int i = 0; i < 長さ; i++)
            {
                var 選択位置 = ランダム.Next(半角英数字.Length);

                var 文字 = 半角英数字[選択位置];

                生成文字列.Append(文字);
            }

            ランダム文字列 = 生成文字列.ToString();
            正誤判定 = string.Empty;
            タイマー = new TimeSpan();
            await ストップウォッチ();
        }

        private void 判定()
        {
            if (入力文字列 == ランダム文字列)
            {
                正誤判定 = "正解";
                タイマー起動中 = false;
            }
            else
            {
                正誤判定 = "不正解";
            }
        }
    }
}
