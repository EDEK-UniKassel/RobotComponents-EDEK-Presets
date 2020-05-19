// System Libs
using System;
using System.Collections.Generic;
// Grasshopper Libs
using Grasshopper.Kernel;
// Rhino Libs
using Rhino.Geometry;
// RobotComponents Libs
using RobotComponents.BaseClasses.Definitions;
using RobotComponentsABB.Parameters.Definitions;
using RobotComponentsEDEK.Presets.ExternalAxes;

namespace RobotComponentsEDEK.Components.ExternalAxes
{
    /// <summary>
    /// RobotComponents EDEK IGUS Track preset component. An inherent from the GH_Component Class.
    /// </summary>
    public class EDEK_IGUS_Track_Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the EDEK_IGUS_Track Component class.
        /// </summary>
        public EDEK_IGUS_Track_Component()
          : base("IGUS Track", "IGUS",
              "The EDEK IGUS Track External Linear Axis preset component."
                + System.Environment.NewLine +
                "RobotComponents EDEK Presets : v" + RobotComponentsEDEK.Utils.VersionNumbering.CurrentVersion,
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

            if (!DA.GetData(0, ref name)) { name = "M7DM1"; }
            if (!DA.GetData(1, ref axisPlane)) { axisPlane = new Plane(new Point3d(-350, 125, 109), new Vector3d(0, 0, 1)); }
            if (!DA.GetData(2, ref axis)) { axis = new Vector3d(0, 1, 0); }
            if (!DA.GetData(3, ref axisLimit)) { axisLimit = new Interval(0, 1150); }

            ExternalLinearAxis externalLinearAxis = new ExternalLinearAxis();

            try
            {
                externalLinearAxis = EDEK_IGUS_Track.GetExternalLinearAxis(name, axisPlane, axis, axisLimit);
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
            get { return Properties.Resources.IGUS_Track_Icon; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F9CF01E8-1D64-4411-803B-73302C4C0795"); }
        }
    }
}