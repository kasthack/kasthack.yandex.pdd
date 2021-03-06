﻿using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class ImportMethods : MethodsBase, IImportMethods
    {
        internal ImportMethods(DomainRawContext context) : base(context) { }

        public async Task<string> CheckSettings(ImportSettings settings) =>
                await Context.ProcessRequestGet("import/check_settings", new Dictionary<string, string> {
                        { nameof( settings.Method ).ToLowerInvariant(), settings.Method.ToNCString() },
                        { nameof( settings.Port ).ToLowerInvariant(), settings.Port.ToNCString() },
                        { nameof( settings.Ssl ).ToLowerInvariant(), settings.Ssl.ToYesNo() },
                        { nameof( settings.Server ).ToLowerInvariant(), settings.Server },
                    }).ConfigureAwait(false);

        public async Task<string> StartOneImport(SingleImportSettings settings) =>
                await Context.ProcessRequestPost("import/start_one_import",
                    new Dictionary<string, string> {
                        { nameof( settings.Method ).ToLowerInvariant(), settings.Method.ToNCString() },
                        { nameof( settings.Port ).ToLowerInvariant(), settings.Port.ToNCString() },
                        { nameof( settings.Ssl ).ToLowerInvariant(), settings.Ssl.ToYesNo() },
                        { nameof( settings.Server ).ToLowerInvariant(), settings.Server },
                        { "ext-login", settings.ExternalLogin },
                        { "ext-passwd", settings.ExternalPassword },
                        { "int-login", settings.InternalLogin },
                        { "int-passwd", settings.InternalPassword },
                    }).ConfigureAwait(false);

        public async Task<string> CheckImport(int? page = null, int? onPage = null) =>
                await Context.ProcessRequestGet("import/check_imports", new Dictionary<string, string> {
                        { nameof( page ), page.ToNCString() },
                        { nameof( onPage ).ToSnake(), onPage.ToNCString() }
                    }).ConfigureAwait(false);

        public async Task<string> StopAllImports() =>
            await Context.ProcessRequestPost("import/stop_all_imports", EmptyParams).ConfigureAwait(false);

        public async Task<string> StartImportFile(ImportSettings settings, string filename)
        {
            using (var file = File.OpenRead(filename))
                return await StartImportFile(settings, file).ConfigureAwait(false);
        }
        public async Task<string> StartImportFile(ImportSettings settings, Stream file) =>
            await Context.ProcessRequestPostForm("import/start_import_file", new MultipartFormDataContent {
                MiscTools.StringContent( nameof( settings.Method ).ToLowerInvariant(), settings.Method.ToNCString() ),
                MiscTools.StringContent( nameof( settings.Port ).ToLowerInvariant(), settings.Port.ToNCString() ),
                MiscTools.StringContent( nameof( settings.Ssl ).ToLowerInvariant(), settings.Ssl.ToYesNo() ),
                MiscTools.StringContent( nameof( settings.Server ).ToLowerInvariant(), settings.Server ),
                MiscTools.StreamContent( nameof( file ), file )
            });

    }
}