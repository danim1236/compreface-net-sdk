﻿using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.SubjectDTOs.AddSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteAllSubjects;
using Exadel.Compreface.DTOs.SubjectDTOs.DeleteSubject;
using Exadel.Compreface.DTOs.SubjectDTOs.GetSubjectList;
using Exadel.Compreface.DTOs.SubjectDTOs.RenameSubject;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.Services
{
    public class SubjectServiceTests
    {
        private SubjectService _subjectService;

        private AddSubjectRequest _addSubjectRequest;
        private RenameSubjectRequest _renameSubjectRequest;
        private DeleteSubjectRequest _deleteSubjectRequest;

        public SubjectServiceTests()
        {
            var configuration = new ComprefaceConfiguration(API_KEY_RECOGNITION_SERVICE, BASE_URL);
            var client = new ComprefaceClient(configuration);
            var subjectName = "Some guy's name 1";
            var renamedSubjectName = "Unknown";

            _subjectService = client.SubjectService;

            _addSubjectRequest = new AddSubjectRequest
            {
                Subject = subjectName
            };
            _renameSubjectRequest = new RenameSubjectRequest
            {
                CurrentSubject = subjectName,
                Subject = renamedSubjectName
            };
            _deleteSubjectRequest = new DeleteSubjectRequest
            {
                ActualSubject = subjectName
            };
        }

        [Fact]
        public async void GetAllSubject_Executes_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.IsType<GetAllSubjectResponse>(response);
        }

        [Fact]
        public async void GetAllSubject_Executes_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.GetAllSubject();

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void AddSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.AddSubject(_addSubjectRequest);

            // Assert
            Assert.IsType<AddSubjectResponse>(response);

            // Clear
            await _subjectService.DeleteSubject(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
        }

        [Fact]
        public async void AddSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.AddSubject(_addSubjectRequest);

            // Assert
            Assert.NotNull(response);
            await _subjectService.DeleteSubject(new DeleteSubjectRequest { ActualSubject = _addSubjectRequest.Subject });
        }

        [Fact]
        public async void AddSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.AddSubject(null!);

            // Assert
            await Assert.ThrowsAsync<ServiceException>(func);
        }

        [Fact]
        public async void RenameSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            var renamedSubjectDeleteRequest = new DeleteSubjectRequest
            {
                ActualSubject = _renameSubjectRequest.Subject
            };
            await _subjectService.AddSubject(_addSubjectRequest);

            // Act
            var response = await _subjectService.RenameSubject(_renameSubjectRequest);
            await _subjectService.DeleteSubject(renamedSubjectDeleteRequest);

            // Assert
            Assert.IsType<RenameSubjectResponse>(response);
        }

        [Fact]
        public async void RenameSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            var renamedSubjectDeleteRequest = new DeleteSubjectRequest
            {
                ActualSubject = _renameSubjectRequest.Subject
            };
            await _subjectService.AddSubject(_addSubjectRequest);

            // Act
            var response = await _subjectService.RenameSubject(_renameSubjectRequest);
            await _subjectService.DeleteSubject(renamedSubjectDeleteRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void RenameSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.RenameSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void DeleteSubject_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Arrange
            await _subjectService.AddSubject(_addSubjectRequest);

            // Act
            var response = await _subjectService.DeleteSubject(_deleteSubjectRequest);

            // Assert
            Assert.IsType<DeleteSubjectResponse>(response);
        }

        [Fact]
        public async void DeleteSubject_TakesRequestModel_ReturnsNotNull()
        {
            // Arrange
            await _subjectService.AddSubject(_addSubjectRequest);

            // Act
            var response = await _subjectService.DeleteSubject(_deleteSubjectRequest);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async void DeleteSubject_TakesNullRequestModel_ThrowsNullReferenceException()
        {
            // Act
            var func = async () => await _subjectService.DeleteSubject(null!);

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public async void DeleteAllSubjects_TakesRequestModel_ReturnsProperResponseModel()
        {
            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.IsType<DeleteAllSubjectsResponse>(response);
        }

        [Fact]
        public async void DeleteAllSubjects_TakesRequestModel_ReturnsNotNull()
        {
            // Act
            var response = await _subjectService.DeleteAllSubjects();

            // Assert
            Assert.NotNull(response);
        }
    }
}
