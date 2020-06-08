using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class GameLoopController
    {
        private Renderer graphics;
        private SceneManager scene;
        private object save;

        public GameLoopController(int cols, int rows)
        {
            scene = new SceneManager(cols, rows);

            graphics = new Renderer(scene.Room);

            ScheduledUpdate();
        }

        private void ScheduledUpdate()
        {
            graphics.Render();
        }
    }
}
