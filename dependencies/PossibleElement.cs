using Elements.Geometry;
using Elements.Geometry.Solids;
using HyparPickElement;
using Newtonsoft.Json;

namespace Elements
{
    public partial class PossibleElement : GeometricElement
    {
        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        public string Description { get; set; }

        public PossibleElement(PossibleElementOverrideAddition add)
        {
            this.AddId = add.Id;
            this.Transform = add.Value.Transform;
            this.Description = add.Value.Description;

            GenerateGeometry();
        }

        public bool Match(PossibleElementIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        public PossibleElement Update(PossibleElementOverride edit)
        {
            this.Transform = edit.Value.Transform;
            this.Description = edit.Value.Description;
            GenerateGeometry();

            return this;
        }

        public void GenerateGeometry()
        {
            this.RepresentationInstances = new List<RepresentationInstance>();

            this.RepresentationInstances.Add(
                new RepresentationInstance(
                    new SolidRepresentation(
                        new Extrude(Polygon.Rectangle(2, 2), 2, Vector3.ZAxis)
                    ),
                    BuiltInMaterials.Glass
                )
            );
        }
    }
}