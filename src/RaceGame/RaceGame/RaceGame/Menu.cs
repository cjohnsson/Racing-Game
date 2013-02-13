using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RaceGame
{
    public class Menu
    {
        private Texture2D _backgroundImage;
        private const int NUMBER_OF_BUTTONS = 3;
        private int BUTTON_HEIGHT;
        private int BUTTON_WIDTH;
        private Color[] button_colors = new Color[NUMBER_OF_BUTTONS];
        private Rectangle[] button_rectangles = new Rectangle[NUMBER_OF_BUTTONS];
        private BState[] button_states = new BState[NUMBER_OF_BUTTONS];
        private Texture2D[] button_textures = new Texture2D[NUMBER_OF_BUTTONS];
        private bool mousePressed;
        private bool prev_mousePressed;
        private int mouseX;
        private int mouseY;

        public Menu(Texture2D backgroundImage, Texture2D startButtonImage, Texture2D continueButtonImage, Texture2D exitButtonImage)
        {
            _backgroundImage = backgroundImage;
            BUTTON_WIDTH = startButtonImage.Bounds.Width;
            BUTTON_HEIGHT = startButtonImage.Bounds.Height;

            button_textures[(int)MenuItems.Start] = startButtonImage;
            button_textures[(int)MenuItems.Continue] = continueButtonImage;
            button_textures[(int)MenuItems.Exit] = exitButtonImage;
            int x = backgroundImage.Bounds.Width / 2 - BUTTON_WIDTH / 2;
            int y = backgroundImage.Bounds.Height / 2 - NUMBER_OF_BUTTONS / 2 * BUTTON_HEIGHT - (NUMBER_OF_BUTTONS % 2) * BUTTON_HEIGHT / 2;
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                button_states[i] = BState.UP;
                button_colors[i] = Color.White;
                button_rectangles[i] = new Rectangle(x, y, BUTTON_WIDTH, BUTTON_HEIGHT);
                y += BUTTON_HEIGHT;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundImage, new Rectangle(0, 0, _backgroundImage.Bounds.Width, _backgroundImage.Bounds.Height), Color.White);

            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
                spriteBatch.Draw(button_textures[i], button_rectangles[i], button_colors[i]);
        }

        public void Update()
        {
            // update mouse variables
            MouseState mouse_state = Mouse.GetState();
            mouseX = mouse_state.X;
            mouseY = mouse_state.Y;
            prev_mousePressed = mousePressed;
            mousePressed = mouse_state.LeftButton == ButtonState.Pressed;

            update_buttons();
        }

        // wrapper for hit_image_alpha taking Rectangle and Texture
        Boolean hit_image_alpha(Rectangle rect, Texture2D tex, int x, int y)
        {
            return hit_image_alpha(0, 0, tex, tex.Width * (x - rect.X) /
                rect.Width, tex.Height * (y - rect.Y) / rect.Height);
        }

        // wraps hit_image then determines if hit a transparent part of image 
        Boolean hit_image_alpha(float tx, float ty, Texture2D tex, int x, int y)
        {
            if (hit_image(tx, ty, tex, x, y))
            {
                uint[] data = new uint[tex.Width * tex.Height];
                tex.GetData<uint>(data);
                if ((x - (int)tx) + (y - (int)ty) *
                    tex.Width < tex.Width * tex.Height)
                {
                    return ((data[
                        (x - (int)tx) + (y - (int)ty) * tex.Width
                        ] &
                                0xFF000000) >> 24) > 20;
                }
            }
            return false;
        }

        // determine if x,y is within rectangle formed by texture located at tx,ty
        Boolean hit_image(float tx, float ty, Texture2D tex, int x, int y)
        {
            return (x >= tx &&
                x <= tx + tex.Width &&
                y >= ty &&
                y <= ty + tex.Height);
        }

        // determine state and color of button
        void update_buttons()
        {
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                if (hit_image_alpha(
                    button_rectangles[i], button_textures[i], mouseX, mouseY))
                {
                    if (mousePressed)
                    {
                        // mouse is currently down
                        button_states[i] = BState.DOWN;
                        button_colors[i] = Color.Blue;
                    }
                    else if (!mousePressed && prev_mousePressed)
                    {
                        // mouse was just released
                        if (button_states[i] == BState.DOWN)
                        {
                            // button i was just down
                            button_states[i] = BState.JUST_RELEASED;
                        }
                    }
                    else
                    {
                        button_states[i] = BState.HOVER;
                        button_colors[i] = Color.LightBlue;
                    }
                }
                else
                {
                    button_states[i] = BState.UP;

                    button_colors[i] = Color.White;
                }

                if (button_states[i] == BState.JUST_RELEASED)
                {
                    take_action_on_button(i);
                }
            }
        }


        // Logic for each button click goes here
        void take_action_on_button(int i)
        {
            //take action corresponding to which button was clicked
            switch (i)
            {
                case (int)MenuItems.Start:
                    break;
                case (int)MenuItems.Continue:
                    
                    break;
                case (int)MenuItems.Exit:
                    
                    break;
            }
        }
    }
}
