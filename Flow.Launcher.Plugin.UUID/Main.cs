using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Flow.Launcher.Plugin.UUID
{
    /// <summary>
    /// The Plugin!
    /// </summary>
    public class UUID : IPlugin
    {
        private PluginInitContext _context;
        private string _iconPath;

        /// <summary>
        /// Initializes
        /// </summary>
        /// <param name="context"></param>
        public void Init(PluginInitContext context)
        {
            _context = context;
            _iconPath =
                Path.Combine(
                    Path.GetDirectoryName(
                        new Uri(typeof(UUID).Assembly.Location).LocalPath
                    ) ?? throw new InvalidOperationException("Can't find containing directory for plugin"),
                    "icon.png"
                );
        }

        /// <summary>
        /// Queries
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Result> Query(Query query)
        {
            return new List<Result>()
            {
                CreateResult(),
                CreateResult(),
                CreateResult()
            };
        }

        private Result CreateResult()
        {
            var uuid = Guid.NewGuid().ToString();
            return new Result()
            {
                Title = uuid,
                IcoPath = _iconPath,
                Action = _ =>
                {
                    Clipboard.SetText(uuid);
                    return true;
                }
            };
        }
    }
}