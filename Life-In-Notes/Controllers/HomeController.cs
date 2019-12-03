﻿using Life_In_Notes.Models;
using Life_In_Notes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntryRepository _entryRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        private readonly UserManager<Account> currentUser;

        // Constructor
        public HomeController(IEntryRepository entryRepository,
                              INoteRepository noteRepository,
                              IHostingEnvironment hostingEnvironment,
                              ILogger<HomeController> logger,
                              UserManager<Account> currentUser)
        {
            _entryRepository = entryRepository;
            _noteRepository = noteRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            
            this.currentUser = currentUser;
        }

        // Returns a list of Entries
        public ViewResult Index()
        {
            string currentId = currentUser.GetUserId(HttpContext.User);

            var model = _entryRepository.GetAllEntries(currentId);
            
            return View(model);
        }

        // Returns a list of Notes
        public ViewResult IndexNotes(int entryID)
        {
            var rootEntry = _entryRepository.GetEntry(entryID);

            ViewData["EntryName"] = rootEntry.Name;

            var model = _noteRepository.GetAllNotes(entryID);

            return View(model);
        }

        // Returns a single entry for a given entry ID
        public ViewResult Details(int? id)
        {
            // types of log
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            // Retrieve information to see if ID value exists
            Entry entry = _entryRepository.GetEntry(id.Value);
            // Note note = _noteRepository.GetAllNotes(entry.Id);

            // Check if entry is NULL
            if (entry == null)
            {
                // Set status to 404
                Response.StatusCode = 404;

                // Return Custom Error View
                return View("EntryNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                Entry = entry,
                PageTitle = "Entry Details"
            };

            if (homeDetailsViewModel.Entry.RefDate == null)
            {
                homeDetailsViewModel.Entry.RefDate = "0000-00-00";
            }

            return View(homeDetailsViewModel);
        }

        // Returns a single note for a given note ID
        public ViewResult DetailsNote(int? id)
        {
            // types of log
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            // Retrieve information to see if ID value exists
            Note note = _noteRepository.GetNote(id.Value);

            // Check if entry is NULL
            if (note == null)
            {
                // Set status to 404
                Response.StatusCode = 404;

                // Return Custom Error View
                return View("NoteNotFound", id.Value);
            }

            NoteDetailsViewModel noteDetailsViewModel = new NoteDetailsViewModel
            {
                Note = note,
                PageTitle = "Note Details"
            };

            if (noteDetailsViewModel.Note.RefDate == null)
            {
                noteDetailsViewModel.Note.RefDate = "0000-00-00";
            }

            return View(noteDetailsViewModel);
        }

        [AllowAnonymous]
        public ViewResult AboutPage()
        {
            return View();
        }

        [HttpGet]
        // Calls the CreateEntry page
        public ViewResult CreateEntry()
        {
            // Return and generate the CreateEntry page
            return View();
        }

        [HttpPost]
        // Creates a new Entry to the repository
        public IActionResult CreateEntry(EntryCreateViewModel model)
        {
            // checking validation of required areas
            if (ModelState.IsValid)
            {
                // add new entry to the entry repository
                Entry newEntry = new Entry
                {
                    Name = model.Name,
                    Type = model.Type,
                    Theme = model.Theme,
                    Date = model.Date,
                    RefDate = model.RefDate,
                    Content = model.Content,
                    UserId = currentUser.GetUserId(HttpContext.User)
                };

                // Check if RefDate is filled
                if (newEntry.RefDate == null)
                {
                    newEntry.RefDate = "0000-00-00";
                }

                // Add new Entry to the repository
                _entryRepository.Add(newEntry);

                // after creating new entry redirect to details page
                return RedirectToAction("Details", new { id = newEntry.Id });
            }

            // Return to view if condition not met
            return View();
        }

        [HttpGet]
        // Calls the Update page
        public ViewResult UpdateEntry(int id)
        {
            // Find the Entry
            Entry entry = _entryRepository.GetEntry(id);
            EntryUpdateViewModel entryUpdateViewModel = new EntryUpdateViewModel
            {
                Id = entry.Id,
                Name = entry.Name,
                Type = entry.Type,
                Theme = entry.Theme,
                Date = entry.Date,
                RefDate = entry.RefDate,
                Content = entry.Content,
                UserId = entry.UserId
            };
            
            // Return and generate the Update page
            return View(entryUpdateViewModel);
        }

        [HttpPost]
        // Updates an Entry to the repository
        public IActionResult UpdateEntry(EntryUpdateViewModel model)
        {
            // checking validation of required areas
            if (ModelState.IsValid)
            {
                // find the ENTRY to be updated via entry repository
                Entry updatedEntry = _entryRepository.GetEntry(model.Id);

                // update the areas/variables
                updatedEntry.Name = model.Name;
                updatedEntry.Type = model.Type;
                updatedEntry.Theme = model.Theme;
                updatedEntry.Date = model.Date;
                updatedEntry.RefDate = model.RefDate;
                updatedEntry.Content = model.Content;
                updatedEntry.UserId = model.UserId;
                
                // Check if RefDate is filled
                if (updatedEntry.RefDate == null)
                {
                    updatedEntry.RefDate = "0000-00-00";
                }

                // Update the database
                _entryRepository.Update(updatedEntry);

                // after creating new entry redirect to details page
                return RedirectToAction("Index");
            }

            // Return view is conditions are not met
            return View();
        }

        public ViewResult EntryNotFound()
        {
            return View();
        }
    }
}