import open3d as o3d
import sys
import getopt
import os


def generate_mesh(app_id):
    appdata = os.getenv('APPDATA')
    app_path = os.path.join(appdata, 'PhotogrammetryTcc',
                            'TempImages', app_id, 'processed_images')

    pointcloud_path = os.path.join(app_path, 'pointcloud.ply')
    result_path = os.path.join(app_path, 'result.obj')

    pcd = o3d.io.read_point_cloud(pointcloud_path)
    mesh, _ = o3d.geometry.TriangleMesh.create_from_point_cloud_poisson(
        pcd, depth=7)

    o3d.visualization.draw_geometries([mesh], width=800, height=600)
    o3d.io.write_triangle_mesh(result_path, mesh)
    return


def main(argv):
    app_id = ''
    opts, args = getopt.getopt(argv, "a:", ["appid="])
    for opt, arg in opts:
        if opt in ("-a", "--appid"):
            app_id = arg

    generate_mesh(app_id)
    return


if __name__ == "__main__":
    main(sys.argv[1:])
