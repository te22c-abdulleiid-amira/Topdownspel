using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "whaaat");
Raylib.SetTargetFPS(60);

// int x = 0;

Color hotPink = new Color(255, 105, 180, 255);

Vector2 position = new Vector2(0, 0);
Vector2 movement = new Vector2(2, 1);
Rectangle wall = new Rectangle(20, 300, 400, 20);
Rectangle characterRect = new Rectangle(0, 600-64, 64, 64);
Rectangle doorRect = new Rectangle(700, 10, 60, 60);
Texture2D characterImage = Raylib.LoadTexture("hellokitty.png"); //här valde jag bilden som man spelat som

string scene = "start";

float speed = 5.6f;
int points = 0;

while (!Raylib.WindowShouldClose())
{
    // x++;
    // position.X++;

    if (scene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }

    // här så skrev jag coder för att styra figuren man spelar med
    else if (scene == "game")
    {
        movement = Vector2.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            movement.Y = -5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            movement.Y = 5;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            movement.X = 5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            movement.X = -5;
        }

        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * speed;
        }
        characterRect.x += movement.X;
        characterRect.y += movement.Y;

        // så karaktären inte går utanför mappan
        if (characterRect.x > 800 - 64 || characterRect.x < 0)
        {
            characterRect.x -= movement.X;
        }
        if (characterRect.y > 600 - 64 || characterRect.y < 0)
        {
            characterRect.y -= movement.Y;
        }

        // förflytning utanför mappen
        // if (characterRect.x > 800 )
        // {
        //     characterRect.x = -64;
        //     characterRect.x = 64;
        //    }

        // Kolla kollisionerna

        if (Raylib.CheckCollisionRecs(characterRect, doorRect))
        {
            // scene = "finished";
            points++;
        }

    }
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    // Raylib.DrawRectangleRec(characterRect, Color.DARKPURPLE);

    // Raylib.DrawCircle(x, 300, 50, Color.GREEN);
    // Raylib.DrawCircleV(position, 50, hotPink);

    // när karaktären rör sig ska du normalisera den och använda "speed"



    if (scene == "game")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);

        Raylib.DrawRectangleRec(doorRect, Color.GREEN);
        Raylib.DrawText($"points: {points}", 10, 10, 32, Color.WHITE);

        

    }
    else if (scene == "game over")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(doorRect, Color.RED);
    }



    // startmenyn
    else if (scene == "start")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("slå största knappen", 250, 250, 30, Color.LIGHTGRAY);
    }
    // Raylib.DrawRectangle(20, 690, 420, 50, Color.VIOLET);
    Raylib.EndDrawing();
}
