import open3d as o3d

pcd = o3d.io.read_point_cloud('pointcloud.ply')
# o3d.visualization.draw_geometries([pcd], width=800, height=600)
with o3d.utility.VerbosityContextManager(
        o3d.utility.VerbosityLevel.Debug) as cm:
    mesh, densities = o3d.geometry.TriangleMesh.create_from_point_cloud_poisson(
        pcd, depth=6)

# o3d.visualization.draw_geometries([mesh], width=800, height=600)
o3d.io.write_triangle_mesh("result.obj", mesh)
