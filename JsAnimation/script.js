var context;
var gradient;
var backgroundColor = "#CCCCCC";
var myCanvas, myVar, myTreeVar, x0, y0, myRadius;
var myAngle = 0;
var myCircle, myColor, myRadius;
var myAlpha;
var myRx, myRy;
var myCircles1 = [];
var tree, trees = [];
var tank1, tank2;
var button;
var missle, wreck;
//=================================================================================================

const updateCanvas = () => {
    myCanvas = document.getElementById( "myCanvas" );
    context = myCanvas.getContext( "2d" );

    context.fillRect( 0, 0, myCanvas.width, myCanvas.height );
    
    //--------------------------------------------
    for( let i = 0; i < 6; i++ ) {
        myColor = "#60654a";
        myRadius = 35;
        myRx = 200 + myRadius * 2 * i;
        myRy = myCanvas.height - myRadius - 20;
        myAlpha = Math.floor( Math.random() * 360 );
        myCircle = new Circle( myColor, myRadius, myRx, myRy, myAlpha );
        myCircles1.push( myCircle );
    }
    //--------------------------------------------
    tank1 = new Tank( true );
    tank2 = new Tank( false );
    missle = new Missle(myCanvas.width * 3, myCanvas.height * 3);
    wreck = new Wreck();

    myVar = setTimeout( nextFrame, 100 );
    myTreeVar = setTimeout( nextTreeAnimation, 100 );
}
//=================================================================================================
class Circle {
    constructor(color, radius, rX, rY, alpha) {
        this.X = 0;
        this.Y = 0;
        this.R = radius;
        this.Color = color;
        this.A = alpha;
        this.trX = rX;
        this.trY = rY;
    }
    display = () => {
    context.fillStyle = this.Color;
    context.beginPath();
    context.arc(this.X, this.Y, this.R, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
//=================================================================================================
    context.fillStyle = backgroundColor;
    context.beginPath();
    context.arc(this.X, this.Y, this.R / 3, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
//=================================================================================================
    context.fillStyle = this.Color;
    context.beginPath();
    context.arc(this.X, this.Y, this.R / 8, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
//=================================================================================================
    context.fillStyle = backgroundColor;
    context.beginPath();
    context.arc(this.X, this.Y + this.R / 1.4, this.R / 6, 0, Math.PI * 2, true);
    context.arc(this.X, this.Y - this.R / 1.4, this.R / 6, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
    context.beginPath();
    context.arc(this.X + this.R / 1.4, this.Y, this.R / 6, 0, Math.PI * 2, true);
    context.arc(this.X - this.R / 1.4, this.Y, this.R / 6, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
    context.beginPath();
    context.arc(this.X + this.R / 2.1, this.Y + this.R / 2.1, this.R / 6, 0, Math.PI * 2, true);
    context.arc(this.X + this.R / 2.1, this.Y - this.R / 2.1, this.R / 6, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
    context.beginPath();
    context.arc(this.X - this.R / 2.1, this.Y + this.R / 2.1, this.R / 6, 0, Math.PI * 2, true);
    context.arc(this.X - this.R / 2.1, this.Y - this.R / 2.1, this.R / 6, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
    };
}
//=================================================================================================
class Tree {
    constructor(rX, rY) {
        this.X = 0;
        this.Y = 0;
        this.trX = rX;
        this.trY = rY;
    };
    display = () => {
        context.fillStyle = "#4b4127";
        context.beginPath();
        context.rect(this.X - 0.5, this.Y, 1, 2.5);
        context.closePath();
        context.fill();
        context.fillStyle = "#213e1b";
        context.beginPath();
        context.arc(this.X - 1, this.Y, 1, 0, Math.PI * 2, true);
        context.arc(this.X + 1, this.Y, 1, 0, Math.PI * 2, true);
        context.arc(this.X, this.Y - 1, 1, 0, Math.PI * 2, true);
        context.closePath();
        context.fill();
    }
    setReferencePoint = (x, y) => {
        this.X0 = x;
        this.Y0 = y;
    };
    setScale = (s) => {
        this.S = s;
    };
    
}
//=================================================================================================

const nextFrame = () => {
    context = myCanvas.getContext( "2d" );

    context.clearRect( 0, 0, myCanvas.width, myCanvas.height );
//-------------------------------------------------------------------
for ( i = 0; i < trees.length; i ++ ) {
    var tree = trees[ i ];
    var treeScale = tree.S;
    if ( treeScale == 1 ) { 
        tree.setReferencePoint( tree.X0 - 2, tree.Y0 );
        context.save();
            context.transform( 10, 0, 0, 10, tree.X0, tree.Y0 );
            tree.display();
        context.restore();
    }
    else 
        if ( treeScale == 2 ) {
            tree.setReferencePoint( tree.X0 - 4, tree.Y0 );
            context.save();
                context.transform( 20, 0, 0, 20, tree.X0, tree.Y0 );
                tree.display();
            context.restore();
        }
    if ( tree.X0 < 0 ) trees.splice( i, 1 );
}
//-------------------------------------------------------------------

    myAngle += 10;
    myAngle %= 360;

    var maxRadius = myCircles1[ 0 ].R;
    for ( var i = 1; i < myCircles1.length; i ++ )
    {
        if ( myCircles1[ i ].R > maxRadius ) maxRadius = myCircles1[ i ].R;
    }

    for ( i = 0; i < myCircles1.length; i ++ )
    {
        myCircle = myCircles1[ i ];
        var sinA = Math.sin( ( myAngle + myCircle.A ) * Math.PI / 180.0 * maxRadius / myCircle.R );
        var cosA = Math.cos( ( myAngle + myCircle.A ) * Math.PI / 180.0 * maxRadius / myCircle.R );
        context.save();
            context.transform( cosA, sinA, -sinA, cosA, myCircle.trX, myCircle.trY );
            myCircle.display();
        context.restore();
    }

 //-------------------------------------------------------------------
//tank2
context.save();
tank2.display();
context.restore();
//-------------------------------------------------------------------
//tank1
context.save();
tank1.display();
context.restore();
//-------------------------------------------------------------------   
//missle
context.save();
missle.display();
context.restore();
//------------------------------------------------------------------- 
context.save();
wreck.display();
context.restore();
//------------------------------------------------------------------- 
    myVar = setTimeout( nextFrame, 30 );
}
//=================================================================================================
const nextTreeAnimation = () => {
        var cY = Math.floor( Math.random() * ( myCanvas.height - 300 ) );
        tree = new Tree( myCanvas.width, cY );
        if ( cY < myCanvas.height / 4 ) tree.setScale( 1 );
        else if ( cY < myCanvas.height / 2 ) tree.setScale( 2 );
        tree.setReferencePoint( myCanvas.width + 40, cY );
        trees.push( tree );
//-------------------------------------------------------------------
    myTreeVar = setTimeout( nextTreeAnimation, 1000 );
}
//=================================================================================================
class Tank {
    constructor(isMain) {
        this.isMain = isMain;
        this.X = myCanvas.width + 20;
        this.Y = -20;
        this.text = Math.floor(Math.random() * 100).toString();
        if( isMain ) {
            this.text = "256";
            this.X = 0;
            this.Y = 0;
        }
    }
    display = () => {
        if (this.X < -1000) {
            this.X = myCanvas.width + 10;
            this.text = Math.floor(Math.random() * 100).toString();
        }
        
        context.beginPath();
        context.moveTo(this.X + 190, this.Y + myCanvas.height - 95);
        context.lineTo(this.X + 210 + myRadius * 10, this.Y + myCanvas.height - 95);
        context.arcTo(this.X + 200 + myRadius * 15, this.Y + myCanvas.height - myRadius - 15, this.X + 210 + myRadius * 10, this.Y + myCanvas.height - 15, myRadius * 1.1);
        context.lineTo(this.X + 190, this.Y + myCanvas.height - 15);
        context.arcTo(this.X + 200 - myRadius * 5, this.Y + myCanvas.height - myRadius - 15, this.X + 190, this.Y + myCanvas.height - 95, myRadius * 1.1);
        context.lineWidth = 10;
        context.strokeStyle = "#4f3e37";
        context.closePath();
        context.stroke();
        
        context.fillStyle = "#404f3d";
        context.fillRect(this.X + 130, this.Y + myCanvas.height - 100 - myRadius * 3, myRadius * 13, myRadius * 3);
        
        context.fillStyle = "#465840";
        context.fillRect(this.X + 260, this.Y + myCanvas.height - 100 - myRadius * 5, myRadius * 6, myRadius * 2);
        
        context.fillStyle = "#4f3e37";
        if( this.isMain ) {
            context.fillRect(this.X + 260 + myRadius * 6, this.Y + myCanvas.height - 100 - myRadius * 4.5, myRadius * 8, myRadius);
        }
        else {
            context.fillRect(this.X + 260 - myRadius * 8, this.Y + myCanvas.height - 100 - myRadius * 4.5, myRadius * 8, myRadius);
        }
        context.fillStyle = "#60654a";
        context.fillRect(this.X + 320, this.Y + myCanvas.height - 100 - myRadius * 5.66, myRadius * 3, myRadius * 0.66);
        

        context.fillStyle = "#f00";
        context.strokeStyle = "#fff";
        context.font = "36px Verdana";
        context.lineWidth = 4;
        if( !this.isMain ) {
            context.strokeText(this.text, this.X + 270, this.Y + myCanvas.height - 100 - myRadius * 3.75);
            context.fillText(this.text, this.X + 270, this.Y + myCanvas.height - 100 - myRadius * 3.75);

            //--------------------------------------------
            for( let i = 0; i < 6; i++ ) {
                context.fillStyle = "#60654a";
                context.beginPath();
                context.arc(this.X + 200 + 2 * i * myRadius, this.Y + 545, myRadius, 0, Math.PI * 2, true);
                context.closePath();
                context.fill();
            }
            //--------------------------------------------
            
            context.fillStyle = "#4f5849";
            context.fillRect(this.X + 160, this.Y + myCanvas.height - myRadius * 4, myRadius * 11.75, myRadius * 3 );
            
            this.X -= 5;
        }
        else {
            context.strokeText(this.text, this.X + 390, this.Y + myCanvas.height - 100 - myRadius * 3.75);
            context.fillText(this.text, this.X + 390, this.Y + myCanvas.height - 100 - myRadius * 3.75);
            
            context.fillStyle = "#fff";
            context.fillRect(this.X + 200, this.Y + myCanvas.height - 100 - myRadius * 3, myRadius, myRadius * 3);    
            context.fillRect(this.X + 130, this.Y + myCanvas.height - 100 - myRadius * 2, myRadius * 13, myRadius);
            
            context.fillStyle = "#000";
            context.fillRect(this.X + 205, this.Y + myCanvas.height - 100 - myRadius * 3, myRadius - 10, myRadius * 3);    
            context.fillRect(this.X + 130, this.Y + myCanvas.height - 95 - myRadius * 2, myRadius * 13, myRadius - 10);
        }
    }
}
class Missle {
    constructor(X = myCanvas.width / 2 - 20, Y = myCanvas.height / 2) {
        this.X = X;
        this.Y = Y;
    }

    display = () => {
        if (this.X < myCanvas.width + 100) {
            this.X += 100;
        }

        context.fillStyle = "#000";
        context.beginPath();
        context.arc(this.X - 20, this.Y + 55, 20, 0, Math.PI * 180, true);
        context.closePath();
        context.fill();
    }
}

const shoot = () => {
    missle = new Missle();
    if(tank2.X > 300 && missle.X > tank2.X - 800) {
        wreck = new Wreck(tank2.X, tank2.Y);
        tank2.X = myCanvas.width + 500;
        tank2.text = Math.ceil(Math.random() * 100).toString();
    }
}
class Wreck {
    constructor(X = -1000, Y = -1000) {
        this.X = X;
        this.Y = Y;
    }

    display = () => {
        context.beginPath();
        context.moveTo(this.X + 190, this.Y + myCanvas.height - 75);
        context.lineTo(this.X + 210 + myRadius * 10, myCanvas.height - 75);
        context.arcTo(this.X + 200 + myRadius * 15, myCanvas.height - myRadius + 5, this.X + 210 + myRadius * 10, this.Y + myCanvas.height + 5, myRadius * 1.1);
        context.lineTo(this.X + 190, myCanvas.height + 20);
        context.arcTo(this.X + 200 - myRadius * 5, myCanvas.height - myRadius + 5, this.X + 190, this.Y + myCanvas.height - 75, myRadius * 1.1);
        context.lineWidth = 10;
        context.strokeStyle = "#4f3e37";
        context.closePath();
        context.stroke();
        
        context.fillStyle = "#404f3d";
        context.fillRect(this.X + 130, myCanvas.height - 90 - myRadius * 3, myRadius * 13, myRadius * 3);
        
        context.fillStyle = "#465840";
        context.fillRect(this.X + 260, this.Y + myCanvas.height - 40 - myRadius * 5, myRadius * 6, myRadius * 2);
        
        context.fillStyle = "#60654a";
        context.fillRect(this.X + 320, this.Y + myCanvas.height - 30 - myRadius * 5.66, myRadius * 3, myRadius * 0.66)
        
        context.fillStyle = "#4f3e37";
        context.fillRect(this.X + 260 - myRadius * 8, myCanvas.height - 70 - myRadius * 4.5, myRadius * 8, myRadius);
    
        this.X -= 3;
    }
}