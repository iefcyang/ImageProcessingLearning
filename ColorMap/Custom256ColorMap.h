#pragma once
#include <qwidget.h>
#include <QMouseEvent>
#include <QPainter>
#include <QColorDialog>


class Custom256ColorMap :
	public QWidget
{
public :
    QColor colorArray[256];
    QRect controlRects[4];
    QRect tempRect;
    bool initialized = false;
public:
    Custom256ColorMap(QWidget* parent) : QWidget(parent)
    {
       
    }

    void Init()
    {
        int Width = width();
        int Height = height();
        float w = Width / 16.0;
        float h = Height / 16.0;


        controlRects[0].setX(0); controlRects[1].setX(0);
        float temp = 15 * w;
        controlRects[2].setX(temp); controlRects[3].setX(temp);
        controlRects[0].setY(0); controlRects[2].setY(0);
        temp = 15 * h;
        controlRects[1].setY(temp); controlRects[3].setY(temp);
 
        // When rectangle setX, width is shifted! So we need to reset width 
        tempRect.setWidth(w);
        tempRect.setHeight(h);
       for (int i = 0; i < 4; i++)
        {
            controlRects[i].setWidth(w);
            controlRects[i].setHeight(h);
        }


        colorArray[0].setRgb(0, 255, 0); // Green top-left
        colorArray[15].setRgb(255, 0, 0); // Red top-right
        colorArray[240].setRgb(0, 0, 255); // Blue bottom-left
        colorArray[255].setRgb(255, 255, 0); // Yellow bottom-right

        updateColors();
        initialized = true;

	}

    void updateColors() // Linear map 4 corner colors
    {
        float rs, rdelta, gs, gdelta, bs, bdelta;
        // first column
        rs = colorArray[0].red(); rdelta = colorArray[240].red() - rs;
        gs = colorArray[0].green(); gdelta = colorArray[240].green() - gs;
        bs = colorArray[0].blue(); bdelta = colorArray[240].blue() - bs;
         
        for (int id = 1, cnt = 16; id < 15; id++, cnt += 16 )
        {
            float ratio = id / 15.0f;
            colorArray[cnt].setRgb(int(rs + rdelta * ratio), int(gs + gdelta * ratio), int(bs + bdelta * ratio));
        }
        // last column
        rs = colorArray[15].red(); rdelta = colorArray[255].red() - rs;
        gs = colorArray[15].green(); gdelta = colorArray[255].green() - gs;
        bs = colorArray[15].blue(); bdelta = colorArray[255].blue() - bs;

        for (int id = 1, cnt = 31; id < 15; id++, cnt += 16)
        {
            float ratio = id / 15.0f;
            colorArray[cnt].setRgb(int(rs + rdelta * ratio), int(gs + gdelta * ratio), int(bs + bdelta * ratio));
        }
        // all rows
        for (int r = 0; r < 16; r++)
        {
            int s = r * 16 , e = s + 15;
            rs = colorArray[s].red();   rdelta = colorArray[e].red() - rs;
            gs = colorArray[s].green(); gdelta = colorArray[e].green() - gs;
            bs = colorArray[s].blue();  bdelta = colorArray[e].blue() - bs;

            for (int id = 1, cnt = r*16 + 1; id < 15; id++, cnt ++)
            {
                float ratio = id / 15.0f;
                colorArray[cnt].setRgb(int(rs + rdelta * ratio), int(gs + gdelta * ratio), int(bs + bdelta * ratio));
            }

        }
    }

    void paintEvent(QPaintEvent*)
    {
        if( !initialized) Init();

        //QRect aaa = QRect();
        //aaa.setWidth(width() - 20);
        //aaa.setHeight(height() - 20);
        //aaa.setX(10); aaa.setY(10);
        double hh = height() / 16.0;
        double ww = width() / 16.0;

        QPainter painter(this);
        
        int cnt = 0;
        for (int r = 0; r < 16; r++)
        {
            tempRect.setY(r * hh);
            tempRect.setHeight(hh);

            for (int c = 0; c < 16; c++)
            {
                tempRect.setX(c * ww);
                tempRect.setWidth(ww);
                painter.fillRect(tempRect, colorArray[cnt++]);
                 painter.drawRect(tempRect);
           }
        }
        QPen pen(Qt::black, 10);
        painter.setPen(pen);
        for (int i = 0; i < 4; i++)
            painter.drawRect(controlRects[i]);
       // painter.drawRect(aaa);
    }

    void mousePressEvent(QMouseEvent* event)
    {
        int x = event->x();
        int y = event->y();
        for (int i = 0; i < 4; i++)
        {
            if (controlRects[i].contains(x, y))
            {
                // show color selection dialog
                QColor ccc =  QColorDialog::getColor();
                if (ccc.isValid())
                {
                    switch (i)
                    {
                    case 0: //
                        colorArray[1] = colorArray[0] = ccc;
                        break;
                    case 1:
                        colorArray[241] = colorArray[240] = ccc;
                        break;
                    case 2:
                        colorArray[14] = colorArray[15] = ccc;
                        break;
                    case 3:
                        colorArray[254] = colorArray[255] = ccc;
                        break;
                    default:
                        break;
                    }

                    // update colors
                    updateColors();
                }
                break;
            }
        }
        //QWidget::mousePressEvent(event);
    }
};

