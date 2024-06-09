using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace MultiRoiPanelMemo
{
    static class DrawIcon
    {
        static public void DrawRoundedTriangle(Graphics g, Brush b, int x, int y, int width, int height, int Angle)
        {
            // 三角形の頂点を計算
            PointF[] points = new PointF[3];
            points[0] = new PointF(x, y - height / 2); // 頂点
            points[1] = new PointF(x - width / 2, y + height / 2); // 左下
            points[2] = new PointF(x + width / 2, y + height / 2); // 右下

            // GraphicsPathを作成し、各辺を追加
            GraphicsPath path = new GraphicsPath();
            path.AddLine(points[0].X, points[0].Y, points[1].X, points[1].Y);
            path.AddLine(points[1].X, points[1].Y, points[2].X, points[2].Y);
            path.AddLine(points[2].X, points[2].Y, points[0].X, points[0].Y);

            // 回転の中心を設定
            Matrix rotateMatrix = new Matrix();
            rotateMatrix.RotateAt(Angle, new PointF(x, y));

            // パスを回転
            path.Transform(rotateMatrix);

            // パスを描画
            g.FillPath(b, path);
            
        }


    }
}
