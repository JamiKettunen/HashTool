namespace System.Windows.Forms
{
    public static class ToolTipEx
    {
        public static void SetTipEx(this ToolTip toolTip, Control control, string tip)
        {
            SetTipRecurse(toolTip, control, tip);
        }

        private static void SetTipRecurse(ToolTip toolTip, Control control, string tip)
        {
            toolTip.SetToolTip(control, tip);

            foreach (Control child in control.Controls)
                SetTipRecurse(toolTip, child, tip);
        }
    }
}