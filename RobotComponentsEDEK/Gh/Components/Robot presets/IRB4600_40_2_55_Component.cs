﻿// System Libs
using System;
using System.Collections.Generic;
// Grasshopper Libs
using Grasshopper.Kernel;
// Rhino Libs
using Rhino.Geometry;
// RobotComponents Libs
using RobotComponents.BaseClasses.Definitions;
using RobotComponentsGoos.Definitions;
using RobotComponentsABB.Parameters.Definitions;

namespace RobotComponentsEDEK.Components
{
    /// <summary>
    /// RobotComponents IRB4600-40/2.55 preset component. An inherent from the GH_Component Class.
    /// </summary>
    public class IRB4600_40_2_55_Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the IRB4600_40_2_55_Component class.
        /// </summary>
        public IRB4600_40_2_55_Component()
          : base("ABB_IRB4600-40/2.55", "IRB4600",
              "An ABB IRB4600-40/2.55 Info preset component."
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
            get { return GH_Exposure.primary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Position Plane", "PP", "Position Plane of the Robot as Plane", GH_ParamAccess.item, Plane.WorldXY);
            pManager.AddParameter(new RobotToolParameter(), "Robot Tool", "RT", "Robot Tool as Robot Tool Parameter", GH_ParamAccess.item);
            pManager.AddParameter(new ExternalAxisParameter(), "External Axis", "EA", "External Axis as External Axis Parameter", GH_ParamAccess.list);

            pManager[1].Optional = true;
            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new RobotInfoParameter(), "Robot Info", "RI", "Resulting Robot Info", GH_ParamAccess.item);  //Todo: beef this up to be more informative.
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Input variables
            Plane positionPlane = Plane.WorldXY;
            GH_RobotTool toolGoo = null;
            List<ExternalAxis> externalAxis = new List<ExternalAxis>();

            if (!DA.GetData(0, ref positionPlane)) { return; }
            if (!DA.GetData(1, ref toolGoo))
            {
                toolGoo = new GH_RobotTool();
            }
            if (!DA.GetDataList(2, externalAxis))
            {
            }

            // Check the axis input: A maximum of one external linear axis is allow
            double count = 0;
            for (int i = 0; i < externalAxis.Count; i++)
            {
                if (externalAxis[i] is ExternalLinearAxis)
                {
                    count += 1;
                }
            }

            // Raise error if more than one external linear axis is used
            if (count > 1)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "At the moment RobotComponents supports one external linear axis.");
            }

            // Robot mesh
            List<Mesh> meshes = new List<Mesh>();
            // Base
            string linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_0;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 1
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_1;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 2
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_2;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 3
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_3;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 4
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_4;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 5
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_5;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));
            // Axis 6
            linkString = RobotComponentsEDEK.Properties.Resources.IRB4600_40_2_55_link_6;
            meshes.Add((Mesh)GH_Convert.ByteArrayToCommonObject<GeometryBase>(System.Convert.FromBase64String(linkString)));

            // Axis planes
            List<Plane> axisPlanes = new List<Plane>() { };
            // Axis 1
            axisPlanes.Add(new Plane(
                new Point3d(0.00, 0.00, 0.00),
                new Vector3d(0.00, 0.00, 1.00)));
            // Axis 2
            axisPlanes.Add(new Plane(
                new Point3d(175.00, 0.00, 495),
                new Vector3d(0.00, 1.00, 0.00)));
            // Axis 3
            axisPlanes.Add(new Plane(
                new Point3d(175.00, 0.00, 1590.00),
                new Vector3d(0.00, 1.00, 0.00)));
            // Axis 4
            axisPlanes.Add(new Plane(
                new Point3d(505.60, 0.00, 1765.00),
                new Vector3d(1.00, 0.00, 0.00)));
            // Axis 5
            axisPlanes.Add(new Plane(
                new Point3d(1445.00, 0.00, 1765.00),
                new Vector3d(0.00, 1.00, 0.00)));
            // Axis 6
            axisPlanes.Add(new Plane(
                new Point3d(1580.00, 0.00, 1765.00),
                new Vector3d(1.00, 0.00, 0.00)));

            // Robot axis limits
            List<Interval> axisLimits = new List<Interval>{
                new Interval(-180, 180),
                new Interval(-90, 150),
                new Interval(-180, 75),
                new Interval(-400, 400),
                new Interval(-120, 125),
                new Interval(-400, 400),};

            // External axis limits
            for (int i = 0; i < externalAxis.Count; i++)
            {
                axisLimits.Add(externalAxis[i].AxisLimits);
            }

            // Tool mounting frame
            Plane mountingFrame = new Plane(
                new Point3d(1580.00, 0.00, 1765.00),
                new Vector3d(1.00, 0.00, 0.00));
            mountingFrame.Rotate(Math.PI * -0.5, mountingFrame.Normal);

            RobotInfo robotInfo;

            // Override position plane when an external axis is coupled
            if (externalAxis.Count != 0)
            {
                for (int i = 0; i < externalAxis.Count; i++)
                {
                    if (externalAxis[i] is ExternalLinearAxis)
                    {
                        positionPlane = (externalAxis[i] as ExternalLinearAxis).AttachmentPlane;
                    }
                }

                robotInfo = new RobotInfo("IRB4600-40/2.55", meshes, axisPlanes, axisLimits, Plane.WorldXY, mountingFrame, toolGoo.Value, externalAxis);
                Transform trans = Transform.PlaneToPlane(Plane.WorldXY, positionPlane);
                robotInfo.Transfom(trans);
            }

            else
            {
                robotInfo = new RobotInfo("IRB4600-40/2.55", meshes, axisPlanes, axisLimits, Plane.WorldXY, mountingFrame, toolGoo.Value);
                Transform trans = Transform.PlaneToPlane(Plane.WorldXY, positionPlane);
                robotInfo.Transfom(trans);
            }

            // Output
            DA.SetData(0, robotInfo);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get { return Properties.Resources.IRB4600_Icon; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("92DFF940-72B1-4D69-AA37-FD4A84D240AD"); }
        }

    }
}