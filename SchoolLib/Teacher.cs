namespace SchoolLib
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public Teacher(int id, string name, string subject, string description)
        {
            Name = name;
            Subject = subject;
            Description = description;
            Id = id;
        }

        public void ValidateName(string name)
        {
            if (name.Length < 2)
            {
                throw new ArgumentException("Name must be at least 2 characters long");
            }
        }

        public void ValidateId(int id)
        {
            if (id < 0 )
            {
                throw new ArgumentException("Id must be a positive number");
            }
        }

        public string ToString()
        {
            return ($"Name: {Name}, Subject: {Subject}, Description: {Description}, Id: {Id}");
        }

    }

}