using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        //bu classa olan ihtiyaç hem lazy loading hem de Eğer IMapper nesnesini
        //proje genelinde Dependency Injection ile kullanıyorsanız, bu sınıfa doğrudan ihtiyacınız olmayabilir.
        //Ancak, Dependency Injection kullanmadan hızlıca Mapper örneğine erişim istiyorsanız bu sınıfı tercih edebilirsiniz.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });

            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;
    }

}
