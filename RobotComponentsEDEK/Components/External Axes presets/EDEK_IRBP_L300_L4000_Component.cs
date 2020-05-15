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
    /// RobotComponents IRBP-L300-L4000 preset component. An inherent from the GH_Component Class.
    /// </summary>
    public class EDEK_IRBP_L300_L4000_Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the EDEK_IRBP_L300_L4000_Component class.
        /// </summary>
        public EDEK_IRBP_L300_L4000_Component()
          : base("IRBP-L300-L4000", "IRBP-L300-L4000",
              "An ABB IRBP-L300-L4000 External Rotational Axis preset component."
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
            pManager.AddTextParameter("Name", "N", "Name of the external rotational axis as a text.", GH_ParamAccess.item, "IRBP-L300-L4000"); //TODO: check name, should be named as defined in controller
            pManager.AddPlaneParameter("Axis Plane", "AP", "Position of the Axis Plane of the External Rotational Axis", GH_ParamAccess.item, Plane.WorldXY);
            pManager.AddMeshParameter("Link Mesh", "LM", "Additional Link meshes as a list with meshes", GH_ParamAccess.list);

            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new ExternalRotationalAxisParameter(), "External Rotational Axis", "ERA", "Resulting External Rotational Axis", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "IRBP-L300-L4000"; //TODO: check name, should be named as defined in controller
            Plane axisPlane = Plane.WorldXY;
            List<Mesh> additionalLinkMeshes = new List<Mesh>() { };

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetData(1, ref axisPlane)) { return; }
            if (!DA.GetDataList(2, additionalLinkMeshes)) { additionalLinkMeshes = new List<Mesh>() { }; }

            ExternalRotationalAxis externalRotationalAxis = new ExternalRotationalAxis();

            try
            {
                externalRotationalAxis = EDEK_IRBP_L300_L4000.GetExternalRotationalAxis(name, axisPlane, additionalLinkMeshes);
            }
            catch (Exception ex)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, ex.Message);
            }

            DA.SetData(0, externalRotationalAxis);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get { return Properties.Resources.IRBP_L300_L4000_Icon; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("E96CF574-9BA3-4948-87EF-BF1698D2DC5F"); }
        }
    }
}