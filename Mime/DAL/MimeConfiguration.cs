using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mime.DAL
{
    public class MimeConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<MvcMovieContext>(options =>
                    options.UseSqlite("Data Source=MvcMovie.db"));

        }
    }
}