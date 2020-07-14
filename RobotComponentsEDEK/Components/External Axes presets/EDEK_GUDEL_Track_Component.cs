// System Libs
using System;
using System.Collections.Generic;
// Grasshopper Libs
using Grasshopper.Kernel;
// Rhino Libs
using Rhino.Geometry;
// RobotComponents Libs
using RobotComponents.Definitions;
using RobotComponentsABB.Parameters.Definitions;
using RobotComponentsEDEK.Presets.ExternalAxes;

namespace RobotComponentsEDEK.Components.ExternalAxes
{
    /// <summary>
    /// RobotComponents EDEK GUDEL Track preset component. An inherent from the GH_Component Class.
    /// </summary>
    public class EDEK_GUDEL_Track_Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the EDEK_GUDEL_Track Component class.
        /// </summary>
        public EDEK_GUDEL_Track_Component()
          : base("GUDEL Track", "GUDEL",
              "The EDEK GUDEL Track External Linear Axis preset component."
                + System.Environment.NewLine +
                "Robot Components EDEK Presets : v" + RobotComponentsEDEK.Utils.VersionNumbering.CurrentVersion,
              "RobotComponents", "EDEK Presets")
        {
        }

        /// <summary>
        /// Override the component exposure (makes the tab subcategory).
        /// Can be set to hidden, primary, secondary, tertiary, quarternary, quinary, senary, septenary, dropdown and obscure
        /// </summary>
        public override GH_Exposure Exposure
        {
            // Use primary for Robot presets
            // Use secondary for External Axes presets
            // Use tertiary for System presets (e.g. Robot + External Axes preset combined in one component)
            // Use quarternay for Robot Tools presets
            // ..
            // Use septenary for all other presets
            get { return GH_Exposure.secondary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Name of the external linear axis as a text.", GH_ParamAccess.item);
            pManager.AddPlaneParameter("Axis Plane", "AP", "Position of the Axis Plane of the External Linear Axis", GH_ParamAccess.item);
            pManager.AddVectorParameter("Axis", "A", "The axis direction as a Vector (in the linear axis coordinate space).", GH_ParamAccess.item);
            pManager.AddIntervalParameter("Axis Limit", "AL", "Axis Limits as Domain", GH_ParamAccess.item);

            pManager[0].Optional = true;
            pManager[1].Optional = true;
            pManager[2].Optional = true;
            pManager[3].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new ExternalLinearAxisParameter(), "External Linear Axis", "ELA", "Resulting External Linear Axis", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "";
            Plane axisPlane = Plane.WorldXY;
            Interval axisLimit = new Interval();
            Vector3d axis = new Vector3d();

            if (!DA.GetData(0, ref name)) { name = EDEK_GUDEL_Track.Name; }
            if (!DA.GetData(1, ref axisPlane)) { axisPlane = EDEK_GUDEL_Track.AxisPlane; }
            if (!DA.GetData(2, ref axis)) { axis = EDEK_GUDEL_Track.Axis; }
            if (!DA.GetData(3, ref axisLimit)) { axisLimit = EDEK_GUDEL_Track.AxisLimit; }

            ExternalLinearAxis externalLinearAxis = new ExternalLinearAxis();

            try
            {
                externalLinearAxis = EDEK_GUDEL_Track.GetExternalLinearAxis(name, axisPlane, axis, axisLimit);
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, ex.Message);
            }

            DA.SetData(0, externalLinearAxis);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get { return Properties.Resources.GUDEL_Track_Icon; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("00E5372E-98F1-4398-AE40-1C19BD58C981"); }
        }
    }
}