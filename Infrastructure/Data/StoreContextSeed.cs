using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try {
                if (!context.Veomaznamenite.Any()) {
                    var veomaznameniteData = File.ReadAllText("../Infrastructure/Data/SeedData/veomaznamenite.json");
                    var veomaznamenite = JsonSerializer.Deserialize<List<Veomaznamenito>>(veomaznameniteData);
                foreach (var item in veomaznamenite)
                {
                    context.Veomaznamenite.Add(item);
                }
                await context.SaveChangesAsync();
                }
                 if (!context.Nezaobilazne.Any()) {
                    var nezaobilazneData = File.ReadAllText("../Infrastructure/Data/SeedData/nezaobilazne.json");
                    var nezaobilazne = JsonSerializer.Deserialize<List<Nezaobilazno>>(nezaobilazneData);
                foreach (var item in nezaobilazne)
                {
                    context.Nezaobilazne.Add(item);
                }
                await context.SaveChangesAsync();
                }
                 if (!context.Znamenitosti.Any()) {
                    var znamenitostiData = File.ReadAllText("../Infrastructure/Data/SeedData/znamenitosti.json");
                    var znamenitosti = JsonSerializer.Deserialize<List<Znamenitost>>(znamenitostiData);
                foreach (var item in znamenitosti)
                {
                    context.Znamenitosti.Add(item);
                }
                await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                    var logger = loggerFactory.CreateLogger<StoreContext>();
                    logger.LogError(ex.Message);
            }
        }
    }
}