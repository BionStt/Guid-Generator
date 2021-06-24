using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GuidGenBlazor.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JavaScriptRuntime { get; set; }

        public string Result { get; set; }

        private void NewGuid()
        {
            Result = Guid.NewGuid().ToString();
        }

        private async Task CopyResult()
        {
            if (!string.IsNullOrWhiteSpace(Result))
            {
                await JavaScriptRuntime.InvokeVoidAsync("clipboardCopy.copyText", Result);
            }
        }
    }
}
