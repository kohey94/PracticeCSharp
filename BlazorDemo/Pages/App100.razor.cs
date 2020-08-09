using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Pages
{
    public partial class App100
    {
        private string 入力文字列 { get; set; } = string.Empty;

        private string ランダム文字列 { get; set; } = string.Empty;

        private string 正誤判定 { get; set; } = string.Empty;

        System.Diagnostics.Stopwatch sw;
        private string タイマー { get; set; }

        private void 文字列生成()
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
        }

        private void 判定()
        {
            if (入力文字列 == ランダム文字列)
            {
                正誤判定 = "正解";
            }
            else
            {
                正誤判定 = "不正解";
            }
        }
    }
}
