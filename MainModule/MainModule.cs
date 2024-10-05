using System;
using CareerHub.repository;
using CareerHub.service;



namespace CareerHub
{
    public class MainModule
    {
        private readonly JobListingService jobListingService;
        private readonly CompanyService companyService;
        private readonly ApplicantService applicantService;
        private readonly CareerHubService careerHubService;

        public MainModule()
        {
            IJobListingRepository jobListingRepository = new JobListingRepository();
            jobListingService = new JobListingService(jobListingRepository);
            ICompanyRepository companyRepository = new CompanyRepository();
            companyService = new CompanyService(companyRepository);
            IApplicantRepository applicantRepository = new ApplicantRepository();
            applicantService = new ApplicantService(applicantRepository);
            var databaseManagerRepository = new DatabaseManagerRepository();
            careerHubService = new CareerHubService(databaseManagerRepository);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 for Admin, 2 for User, 0 to exit):");
                if (!int.TryParse(Console.ReadLine(), out int role))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (role)
                {
                    case 1:
                        Console.WriteLine("Admin Page");
                        AdminMenu();
                        break;
                    case 2:
                        Console.WriteLine("User Page");
                        UserMenu();
                        break;
                    case 0:
                        Console.WriteLine("Career Hub ");
                        return;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        private void AdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nAdmin Page:");
                Console.WriteLine("1. Insert Job ");
                Console.WriteLine("2. Insert  a  Company");
                Console.WriteLine("3. Get all jobs to view");
                Console.WriteLine("4. salary");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        careerHubService.InsertJobListing();
                        break;
                    case 2:
                        careerHubService.InsertCompany();
                        break;
                    case 3:
                        companyService.GetJobs();
                        break;
                    case 4:
                        jobListingService.GetJobsBySalaryRange();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void UserMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nUser Page:");
                Console.WriteLine("1. Get all Applicants");
                Console.WriteLine("2. Apply to a company ");
                Console.WriteLine("3. Create a Profile");
                Console.WriteLine("4. Apply for the Job");
                Console.WriteLine("5. Get all Jobs");
                Console.WriteLine("6. salary range");
                Console.WriteLine("7. Exit");
                Console.Write("Enterchoice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        jobListingService.GetApplicants();
                        break;
                    case 2:
                        jobListingService.Apply();
                        break;
                    case 3:
                        applicantService.CreateProfile();
                        break;
                    case 4:
                        applicantService.ApplyForJob();
                        break;
                    case 5:
                        companyService.GetJobs();
                        break;
                    case 6:
                        jobListingService.GetJobsBySalaryRange();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
