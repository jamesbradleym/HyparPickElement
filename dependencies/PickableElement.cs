using Elements.Geometry;
using Elements.Geometry.Solids;
using HyparPickElement;
using Newtonsoft.Json;

namespace Elements
{
    public partial class PickableElement : GeometricElement
    {

        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        [JsonProperty("Valid Options")]
        public List<string>? ValidOptions { get; set; }
        public List<PossibleElement>? Options { get; set; }

        [JsonProperty("Pick Possible Element")]
        public PossibleElement EnumQueryPickElement { get; set; }

        [JsonProperty("HyparPick Element")]
        public PossibleElement HyparPickElement { get; set; }

        public PickableElement(PickElementOverrideAddition add)
        {
            this.AddId = add.Id;
            this.ValidOptions = (List<string>?)add.Value.ValidOptions;
            this.Transform = add.Value.Transform;

            GenerateGeometry();
        }

        public bool Match(PickElementIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        public PickableElement Update(PickElementOverride edit)
        {
            this.ValidOptions = (List<string>?)edit.Value.ValidOptions;
            this.Transform = edit.Value.Transform;
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
                    BuiltInMaterials.Wood
                )
            );
        }
    }
}