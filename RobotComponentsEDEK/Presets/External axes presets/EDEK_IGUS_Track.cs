// System Libs
using System.Collections.Generic;
// Rhino Libs
using Rhino.Geometry;
// Robot Components Libs
using RobotComponents.BaseClasses.Definitions;
using RobotComponents.Utils;

namespace RobotComponentsEDEK.Presets.ExternalAxes
{
    /// <summary>
    /// Defines the IGUS Track external linear axis
    /// </summary>
    public static class EDEK_IGUS_Track
    {
        /// <summary>
        /// Defines the IGUS track external linear axis
        /// </summary>
        /// <param name="name"> The name of the external linear axis. </param>
        /// <param name="positionPlane"> The position of the axis plane in world coordinate space as plane. </param>
        /// <param name="axis"> The axis direction as a vector. </param>
        /// <param name="axisLimit"> The axis limits as a domain. </param>
        /// <returns> Returns the external linear axis preset. </returns>
        public static ExternalLinearAxis GetExternalLinearAxis(string name, Plane positionPlane, Vector3d axis, Interval axisLimit)
        {
            List<Mesh> meshes = GetMeshes();
            Plane axisPlane = Plane.WorldXY;

            ExternalLinearAxis externalLinearAxis = new ExternalLinearAxis(name, axisPlane, axis, axisLimit, meshes[0], meshes[1]);
            Transform trans = Transform.PlaneToPlane(Plane.WorldXY, positionPlane);
            externalLinearAxis.Transform(trans);

            return externalLinearAxis;
        }

        /// <summary>
        /// Defines the base and link meshes a robot coordinate space. 
        /// </summary>
        /// <returns> Returns a list with meshes. </returns>
            public static List<Mesh> GetMeshes()
        {
            List<Mesh> meshes = new List<Mesh>() { };
            string linkString;

            // Base
            linkString = RobotComponentsEDEK.Properties.Resources.IGUS_track_link_0;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));
            // Axis 1
            linkString = RobotComponentsEDEK.Properties.Resources.IGUS_track_link_1;
            meshes.Add((Mesh)HelperMethods.ByteArrayToObject(System.Convert.FromBase64String(linkString)));

            return meshes;
        }

    }
}
