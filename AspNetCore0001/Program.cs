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

        // �A�v���P�[�V���������s���邽�߂̃z�X�g���쐬����
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // UserStartup��Startup.cs���w�肷��B
                    //webBuilder.UseStartup<Startup>();

                    // StartupXXX�ƃ}�b�`����p�^�[����Startup.cs�𗘗p����ꍇ
                    // XXX��ASPNETCORE_ENVIRONMENT�̒l�ƃ}�b�`����i�v���W�F�N�g>�v���p�e�B>�f�o�b�O�j
                    webBuilder.UseStartup(Assembly.GetEntryAssembly().GetName().Name);
                    
                    //���̒��̊g�����\�b�h�ɂ��A�F��Ȑݒ��ǉ��ł���B
                    // Kestrel�g������AContentRoot�̎w�肵����Aetc
                });
    }
}
