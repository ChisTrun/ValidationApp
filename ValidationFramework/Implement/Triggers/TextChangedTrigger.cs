using System.Windows.Controls;
using ValidationFramework.Base;

namespace ValidationLib.Trigger;

public class TextChangedTrigger : BaseTrigger
{
	private void OnTextChanged(object sender, TextChangedEventArgs e)
	{
		TriggerValidate();
	}

	public override void Attach()
	{
		if (_textBox != null)
		{
			_textBox.TextChanged += OnTextChanged;
		}
	}

	public override void Detach()
	{
		if (_textBox != null)
		{
			_textBox.TextChanged -= OnTextChanged;
		}
	}
}
