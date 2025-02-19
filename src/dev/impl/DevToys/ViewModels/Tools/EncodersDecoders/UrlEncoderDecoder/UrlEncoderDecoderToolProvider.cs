﻿#nullable enable

using System.Composition;
using DevToys.Api.Tools;
using DevToys.Core.Threading;
using DevToys.Shared.Api.Core;
using Windows.UI.Xaml.Controls;

namespace DevToys.ViewModels.Tools.UrlEncoderDecoder
{
    [Export(typeof(IToolProvider))]
    [Name("URL Encoder/Decoder")]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    [ProtocolName("url")]
    [Order(0)]
    internal sealed class UrlEncoderDecoderToolProvider : ToolProviderBase, IToolProvider
    {
        private readonly IMefProvider _mefProvider;

        public string MenuDisplayName => LanguageManager.Instance.UrlEncoderDecoder.MenuDisplayName;

        public string? SearchDisplayName => LanguageManager.Instance.UrlEncoderDecoder.SearchDisplayName;

        public string? Description => LanguageManager.Instance.UrlEncoderDecoder.Description;

        public string AccessibleName => LanguageManager.Instance.UrlEncoderDecoder.AccessibleName;

        public TaskCompletionNotifier<IconElement> IconSource => CreateFontIcon("\uF4E4");

        [ImportingConstructor]
        public UrlEncoderDecoderToolProvider(IMefProvider mefProvider)
        {
            _mefProvider = mefProvider;
        }

        public bool CanBeTreatedByTool(string data)
        {
            return false;
        }

        public IToolViewModel CreateTool()
        {
            return _mefProvider.Import<UrlEncoderDecoderToolViewModel>();
        }
    }
}
