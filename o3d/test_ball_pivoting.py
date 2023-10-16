
import open3d as o3d

pcd = o3d.io.read_point_cloud('pointcloud.ply')

alphas = [0.07, 0.08, 0.1, 0.13, 0.15, 0.17, 0.2]

for alpha in alphas:
    print(f"alpha={alpha:.3f}")
    mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(
        pcd, alpha)
    mesh.compute_vertex_normals()
    o3d.visualization.draw_geometries([mesh], mesh_show_back_face=True)
