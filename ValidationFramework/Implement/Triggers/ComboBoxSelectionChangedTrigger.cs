using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger;

public class ComboBoxSelectionChangedTrigger : BaseTrigger
{
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TriggerValidate();
    }

    public override void Attach()
    {
        if (_control is ComboBox comboBox)
        {
            comboBox.SelectionChanged += OnSelectionChanged;
        }
    }

    public override void Detach()
    {
        if (_control is ComboBox comboBox)
        {
            comboBox.SelectionChanged -= OnSelectionChanged;
        }
    }
}
