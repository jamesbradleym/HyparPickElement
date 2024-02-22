using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace HyparPickElement
{
    public static class HyparPickElement
    {
        /// <summary>
        /// The HyparPickElement function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A HyparPickElementOutputs instance containing computed results and the model with any new elements.</returns>
        public static HyparPickElementOutputs Execute(Dictionary<string, Model> inputModels, HyparPickElementInputs input)
        {
            // Your code here.
            var output = new HyparPickElementOutputs();

            var possibleElements = input.Overrides.PossibleElement.CreateElements(
              input.Overrides.Additions.PossibleElement,
              input.Overrides.Removals.PossibleElement,
              (add) => new PossibleElement(add),
              (possibleElement, identity) => possibleElement.Match(identity),
              (possibleElement, edit) => possibleElement.Update(edit)
            );

            output.Model.AddElements(possibleElements);

            var pickableElements = input.Overrides.PickElement.CreateElements(
              input.Overrides.Additions.PickElement,
              input.Overrides.Removals.PickElement,
              (add) => new PickableElement(add),
              (pickableElement, identity) => pickableElement.Match(identity),
              (pickableElement, edit) => pickableElement.Update(edit)
            );

            foreach (var pickable in pickableElements)
            {
                pickable.Options = possibleElements.Where(pe => pickable.ValidOptions?.Contains(pe.Description) ?? false).ToList();
            }

            output.Model.AddElements(pickableElements);
            return output;
        }
    }
}