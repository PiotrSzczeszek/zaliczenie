using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Zaliczenie.Utils;

public class ButtonsGenerator<T>
{
    private List<Action<RenderTreeBuilder, T, int>> _actions = new();

    public ButtonsGenerator<T> AddButton(Action<T> handler, object handlerReceiver, string buttonClass, string buttonIcon)
    {
        // Store the action to add a button, rather than adding it immediately
        _actions.Add((builder, item, seq) =>
        {
            builder.OpenElement(seq++, "button");
            builder.AddAttribute(seq++, "onclick", EventCallback.Factory.Create(handlerReceiver, () => handler(item)));
            builder.AddAttribute(seq++, "class", buttonClass);
            builder.OpenElement(seq++, "span");
            builder.AddAttribute(seq++, "class", buttonIcon);
            builder.CloseElement();
            builder.CloseElement();
        });

        return this;
    }

    public RenderFragment<T> Build()
    {
        return item => builder =>
        {
            int seq = 0;
            foreach (var action in _actions)
            {
                action(builder, item, seq);
            }
        };
    }
}

//
// public class ButtonsGenerator<T>
// {
//     private RenderTreeBuilder _builder = new();
//     private int i = 0;
//
//     public ButtonsGenerator()
//     {
//     }
//     public ButtonsGenerator<T> AddButton(Action<T> handler, object handlerReceiver, string buttonClass, string buttonText)
//     {
//         _builder.OpenElement(i++, "button");
//         _builder.AddAttribute(i++, "onclick", EventCallback.Factory.Create(handlerReceiver, handler));
//         _builder.AddAttribute(i++, "class", buttonClass);
//         _builder.AddContent(i++, buttonText);
//         _builder.CloseElement();
//
//         return this;
//     }
//
//     public RenderFragment<T> Build()
//     {
//         return (item) => builder =>
//         {
//             var previousSeq = i; // Capture the current sequence
//             i = 0; // Reset the sequence for this render
//             _builder = builder; // Use the provided builder
//
//             // Invoke the configured button additions here
//             // This is where you add your buttons based on the item
//             // For example, you might call AddButton for each button you want to add
//
//             i = previousSeq; // Restore the sequence
//         };
//     }
// }

public static class RenderingUtils
{
    public static RenderFragment<T> GenerateDataTableActionButtons<T>(List<DataTableButtonsConfig<T>> buttons)
    {
        return (item) => builder =>
        {
            var i = 0;
            builder.OpenElement(i++, "td");

            foreach (var button in buttons)
            {
                builder.OpenElement(i++, "button");
                builder.AddAttribute(i++, "onclick", EventCallback.Factory.Create(button.ActionReceiver, () => button.ButtonAction(item)));
                builder.AddAttribute(i++, "class", button.ButtonClass);
                builder.AddContent(i++, button.ButtonText);
                builder.CloseElement();
            }
            
            builder.CloseElement();
        };
    }
}

public class DataTableButtonsConfig<T>
{
    public string ButtonText { get; set; }
    public string ButtonClass { get; set; }
    public Action<T> ButtonAction { get; set; }
    public object ActionReceiver { get; set; }
}