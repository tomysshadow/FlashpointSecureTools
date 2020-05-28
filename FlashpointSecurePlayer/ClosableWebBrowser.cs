﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static FlashpointSecurePlayer.Shared;
using static FlashpointSecurePlayer.Shared.Exceptions;

namespace FlashpointSecurePlayer {
    public partial class ClosableWebBrowser : WebBrowser {
        protected readonly Form form = null;

        public ClosableWebBrowser(Form form) {
            this.form = form;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_PARENTNOTIFY) {
                if (!DesignMode) {
                    if (m.WParam.ToInt32() == WM_DESTROY) {
                        if (form != null) {
                            form.Close();
                        }
                    }
                }

                DefWndProc(ref m);
                return;
            }

            base.WndProc(ref m);
        }
    }
}
