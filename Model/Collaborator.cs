﻿using Newtonsoft.Json;
using System;

namespace TadManagementTool.Model
{
    public class Collaborator
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("genderType")]
        public GenderType Gender { get; set; }

        [JsonProperty("telephones")]
        public Telephone[] Telephones { get; set; }

        [JsonProperty("userRole")]
        public UserRole UserRole { get; set; }

        [JsonProperty("observation")]
        public string Observation { get; set; }

        [JsonProperty("contributor")]
        public bool Contributor { get; set; }

        [JsonIgnore]
        public bool Active { get { return ReleaseDate == null; } }

        [JsonIgnore]
        public Person Person { get { return new Person(Name, BirthDate); } }

        public bool IsCollaborator { get { return UserRole == UserRole.Administrator || UserRole == UserRole.Collaborator || UserRole == UserRole.Financial; } }
    }
}
