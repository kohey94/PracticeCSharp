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

        // �A�v���P�[�V���������s���邽�߂̃z�X�g���쐬����
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //���̒��̊g�����\�b�h�ɂ��A�F��Ȑݒ��ǉ��ł���B
                    // Kestrel�g������AContentRoot�̎w�肵����Aetc
                });
    }
}
