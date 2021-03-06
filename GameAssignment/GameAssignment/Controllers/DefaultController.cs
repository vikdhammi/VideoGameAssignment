﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameAssignment.Context;
using System.Web.Http.Cors;
using GameAssignment.Models;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GameAssignment.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        [Route("api/default/")]
        public IQueryable<Game> GetGames()
        {
            return db.Games;
        }

        [HttpGet]
        [Route("api/default/{id}")]
        public IHttpActionResult GetGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        [Route("api/default/")]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.GameId)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        

        [HttpPost]
        [Route("api/default")]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = game.GameId }, game);
        }

        [HttpDelete]
        [Route(("api/default/{id}"))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.GameId == id) > 0;
        }
    }
}
