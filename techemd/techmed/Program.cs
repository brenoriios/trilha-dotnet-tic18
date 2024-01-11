using System.Globalization;
using Techmed.Model;

var db = new TechmedContext();

void Show()
{
    while (true)
    {
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Gerenciamento de Medicos");
        Console.WriteLine($"2. Gerenciamento de Pacientes");
        Console.WriteLine($"3. Gerenciamento de Consultas");
        Console.WriteLine($"4. Gerenciamento de Exames");
        Console.WriteLine($"0. Sair");

        int op;
        try
        {
            op = int.Parse(Console.ReadLine() ?? "");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Digite uma opção válida!");
            continue;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            continue;
        }

        switch (op)
        {
            case 1:
                DoctorsMenu();
                break;
            case 2:
                PatientsMenu();
                break;
            case 3:
                AppointmentsMenu();
                break;
            case 4:
                ExamsMenu();
                break;
            case 0:
                break;
            default:
                Console.WriteLine($"Opção Inválida");
                break;
        }

        if (op == 0)
        {
            break;
        }
    }
}

void DoctorsMenu()
{
    while (true)
    {
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Cadastrar Medico");
        Console.WriteLine($"2. Editar Medico");
        Console.WriteLine($"3. Excluir Medico");
        Console.WriteLine($"4. Lista de Medicos");
        Console.WriteLine($"0. Voltar");

        int op;
        try
        {
            op = int.Parse(Console.ReadLine() ?? "");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Digite uma opção válida!");
            continue;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            continue;
        }

        switch (op)
        {
            case 1:
                AddDoctor();
                break;
            case 2:
                EditDoctor();
                break;
            case 3:
                RemoveDoctor();
                break;
            case 4:
                ListDoctors();
                break;
            case 0:
                break;
            default:
                Console.WriteLine($"Opção Inválida");
                break;
        }

        if (op == 0)
        {
            break;
        }
    }
}

void PatientsMenu()
{
    while (true)
    {
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Cadastrar Paciente");
        Console.WriteLine($"2. Editar Paciente");
        Console.WriteLine($"3. Excluir Paciente");
        Console.WriteLine($"4. Lista de Pacientes");
        Console.WriteLine($"0. Voltar");

        int op;
        try
        {
            op = int.Parse(Console.ReadLine() ?? "");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Digite uma opção válida!");
            continue;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            continue;
        }

        switch (op)
        {
            case 1:
                AddPatient();
                break;
            case 2:
                EditPatient();
                break;
            case 3:
                RemovePatient();
                break;
            case 4:
                ListPatients();
                break;
            case 0:
                break;
            default:
                Console.WriteLine($"Opção Inválida");
                break;
        }

        if (op == 0)
        {
            break;
        }
    }
}

void AppointmentsMenu()
{
    while (true)
    {
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Cadastrar consulta");
        Console.WriteLine($"2. Adicionar exame na consulta");
        Console.WriteLine($"3. Remover exame da consulta");
        Console.WriteLine($"4. Editar Consulta");
        Console.WriteLine($"5. Excluir Consulta");
        Console.WriteLine($"6. Lista de Consultas");
        Console.WriteLine($"0. Voltar");

        int op;
        try
        {
            op = int.Parse(Console.ReadLine() ?? "");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Digite uma opção válida!");
            continue;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            continue;
        }

        switch (op)
        {
            case 1:
                AddAppointment();
                break;
            case 2:
                AddExamOnAppointment();
                break;
            case 3:
                RemoveExamFromAppointment();
                break;
            case 4:
                EditAppointment();
                break;
            case 5:
                RemoveAppointment();
                break;
            case 6:
                ListAppointments();
                break;
            case 0:
                break;
            default:
                Console.WriteLine($"Opção Inválida");
                break;
        }

        if (op == 0)
        {
            break;
        }
    }
}

void ExamsMenu()
{
    while (true)
    {
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Cadastrar Exame");
        Console.WriteLine($"2. Editar Exame");
        Console.WriteLine($"3. Excluir Exame");
        Console.WriteLine($"4. Lista de Exames");
        Console.WriteLine($"0. Voltar");

        int op;
        try
        {
            op = int.Parse(Console.ReadLine() ?? "");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Digite uma opção válida!");
            continue;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            continue;
        }

        switch (op)
        {
            case 1:
                AddExam();
                break;
            case 2:
                EditExam();
                break;
            case 3:
                RemoveExam();
                break;
            case 4:
                ListExams();
                break;
            case 0:
                break;
            default:
                Console.WriteLine($"Opção Inválida");
                break;
        }

        if (op == 0)
        {
            break;
        }
    }
}


void AddDoctor()
{
    Console.WriteLine($"Nome do médico:");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"Código do médico");
    string code = Console.ReadLine() ?? "";

    Console.WriteLine($"Salário do médico");
    float salary = float.Parse(Console.ReadLine() ?? "");

    Console.WriteLine($"Especialização do médico");
    string specialization = Console.ReadLine() ?? "";


    db.Doctors.Add(new Doctor()
    {
        Name = name,
        Code = code,
        Salary = salary,
        Specialization = specialization
    });

    db.SaveChanges();
    Console.WriteLine($"Médico cadastrado com sucesso!");
}

void EditDoctor()
{
    Console.WriteLine($"Id do Médico");
    int id = int.Parse(Console.ReadLine() ?? "");

    Console.WriteLine($"Nome do médico:");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"Código do médico");
    string code = Console.ReadLine() ?? "";

    Console.WriteLine($"Salário do médico");
    float salary = float.Parse(Console.ReadLine() ?? "");

    Console.WriteLine($"Especialização do médico");
    string specialization = Console.ReadLine() ?? "";

    Doctor? doctor = db.Doctors.FirstOrDefault(m => m.Id == id);

    if (doctor == null)
    {
        return;
    }

    doctor.Name = name;
    doctor.Code = code;
    doctor.Salary = salary;
    doctor.Specialization = specialization;

    db.SaveChanges();
    Console.WriteLine($"Cadastro do médico alterado com sucesso!");    
}

void RemoveDoctor()
{
    Console.WriteLine($"Id do Médico");
    int id = int.Parse(Console.ReadLine() ?? "");
    Doctor? doctor = db.Doctors.Find(id);

    if(doctor == null){
        return;
    }

    db.Doctors.Remove(doctor);

    db.SaveChanges();
    Console.WriteLine($"Médico removido!");
}

void ListDoctors()
{
    db.Doctors.ToList().ForEach(doctor => Console.WriteLine($"{doctor.Id} {doctor.Name} R$ {doctor.Salary}"));
}

void AddPatient()
{
    Console.WriteLine($"Nome do paciente:");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"CPF do paciente");
    string cpf = Console.ReadLine() ?? "";

    Console.WriteLine($"Endereço do paciente");
    string address = Console.ReadLine() ?? "";

    Console.WriteLine($"Telefone do paciente");
    string phone = Console.ReadLine() ?? "";


    db.Patients.Add(new Patient()
    {
        Name = name,
        Cpf = cpf,
        Address = address,
        Phone = phone
    });

    db.SaveChanges();
    Console.WriteLine($"Paciente cadastrado com sucesso!");
}

void EditPatient()
{
    Console.WriteLine($"Id do Paciente");
    int id = int.Parse(Console.ReadLine() ?? "");

    Console.WriteLine($"Nome do paciente:");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"CPF do paciente");
    string cpf = Console.ReadLine() ?? "";

    Console.WriteLine($"Endereço do paciente");
    string address = Console.ReadLine() ?? "";

    Console.WriteLine($"Telefone do paciente");
    string phone = Console.ReadLine() ?? "";

    Patient? patient = db.Patients.FirstOrDefault(p => p.Id == id);

    if (patient == null)
    {
        return;
    }

    patient.Name = name;
    patient.Cpf = cpf;
    patient.Address = address;
    patient.Phone = phone;

    db.SaveChanges();
    Console.WriteLine($"Cadastro do paciente alterado com sucesso!");    
}

void RemovePatient()
{
    Console.WriteLine($"Id do Paciente");
    int id = int.Parse(Console.ReadLine() ?? "");

    Patient? patient = db.Patients.Find(id);

    if(patient == null) {
        return;
    }
    
    db.Patients.Remove(patient);
    db.SaveChanges();
    Console.WriteLine($"Paciente removido!");
}

void ListPatients()
{
    db.Patients.ToList().ForEach(patient => Console.WriteLine($"{patient.Id} {patient.Name} - {patient.Phone}"));
}

void AddAppointment()
{
    Console.WriteLine($"Id do médico:");
    int doctorId = int.Parse(Console.ReadLine() ?? "");
    Doctor? doctor = db.Doctors.Find(doctorId);

    if(doctor == null) {
        return;
    }

    Console.WriteLine($"Id do paciente");
    int patientId = int.Parse(Console.ReadLine() ?? "");
    Patient? patient = db.Patients.Find(patientId);

    if(patient == null) {
        return;
    }

    Console.WriteLine($"Data da consulta dd/mm/aaaa hh:mm");
    string date = Console.ReadLine() ?? "";
    DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

    db.Appointments.Add(new Appointment()
    {
        Doctor = doctor,
        Patient = patient,
        Date = dateTime
    });

    db.SaveChanges();
    Console.WriteLine($"Consulta cadastrada com sucesso!");
}

void EditAppointment()
{
    Console.WriteLine($"Número da Consulta");
    int number = int.Parse(Console.ReadLine() ?? "");
    Appointment? appointment = db.Appointments.Find(number);

    if(appointment == null) {
        return;
    }

    Console.WriteLine($"Id do médico:");
    int doctorId = int.Parse(Console.ReadLine() ?? "");
    Doctor? doctor = db.Doctors.Find(doctorId);

    if(doctor == null) {
        return;
    }

    appointment.Doctor = doctor;

    Console.WriteLine($"Id do paciente");
    int patientId = int.Parse(Console.ReadLine() ?? "");
    Patient? patient = db.Patients.Find(patientId);

    if(patient == null) {
        return;
    }

    appointment.Patient = patient;

    Console.WriteLine($"Data da consulta dd/mm/aaaa hh:mm");
    string date = Console.ReadLine() ?? "";
    DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

    appointment.Date = dateTime;

    db.SaveChanges();
    Console.WriteLine($"Consulta alterada com sucesso!");    
}

void AddExamOnAppointment() {
    Console.WriteLine($"Número da consulta");
    int number = int.Parse(Console.ReadLine() ?? "");
    Appointment? appointment = db.Appointments.Find(number);

    if(appointment == null) {
        return;
    }

    Console.WriteLine($"Código do exame");
    int code = int.Parse(Console.ReadLine() ?? "");
    Exam? exam = db.Exams.Find(code);

    if(exam == null) {
        return;
    }

    appointment.Exams.Add(exam);
    Console.WriteLine($"Exame adicionado a consulta");
}

void RemoveExamFromAppointment() {
    Console.WriteLine($"Número da consulta");
    int number = int.Parse(Console.ReadLine() ?? "");
    Appointment? appointment = db.Appointments.Find(number);

    if(appointment == null) {
        return;
    }

    Console.WriteLine($"Código do exame");
    int code = int.Parse(Console.ReadLine() ?? "");
    Exam? exam = db.Exams.Find(code);

    if(exam == null) {
        return;
    }

    appointment.Exams.Remove(exam);
    Console.WriteLine($"Exame removido da consulta");
}

void RemoveAppointment()
{
    Console.WriteLine($"Número da consulta");
    int number = int.Parse(Console.ReadLine() ?? "");

    Appointment? appointment = db.Appointments.Find(number);

    if(appointment == null) {
        return;
    }
    
    db.Appointments.Remove(appointment);
    db.SaveChanges();
    Console.WriteLine($"Consulta removida!");
}

void ListAppointments()
{
    db.Appointments.ToList().ForEach(appointment => Console.WriteLine($"{appointment.Number} Paciente: {appointment.Patient.Name} | Médico: {appointment.Doctor.Name} | Data: {appointment.Date}"));
}

void AddExam()
{
    Console.WriteLine($"Código do exame:");
    string code = Console.ReadLine() ?? "";

    Console.WriteLine($"Nome do exame");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"Preço do exame");
    float price = float.Parse(Console.ReadLine() ?? "");


    db.Exams.Add(new Exam()
    {
        Code = code,
        Name = name,
        Price = price
    });

    db.SaveChanges();
    Console.WriteLine($"Exame cadastrado com sucesso!");
}

void EditExam()
{
    Console.WriteLine($"Código do exame:");
    string code = Console.ReadLine() ?? "";

    Exam? exam = db.Exams.FirstOrDefault(p => p.Code == code);

    if (exam == null)
    {
        return;
    }

    Console.WriteLine($"Nome do exame");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine($"Preço do exame");
    float price = float.Parse(Console.ReadLine() ?? "");

    exam.Name = name;
    exam.Price = price;

    db.SaveChanges();
    Console.WriteLine($"Exame alterado com sucesso!");    
}

void RemoveExam()
{
    Console.WriteLine($"Código do exame:");
    string code = Console.ReadLine() ?? "";

    Exam? exam = db.Exams.Find(code);

    if(exam == null) {
        return;
    }
    
    db.Exams.Remove(exam);
    db.SaveChanges();
    Console.WriteLine($"Exame removido!");
}

void ListExams()
{
    db.Exams.ToList().ForEach(exam => Console.WriteLine($"{exam.Code} = {exam.Name} R$ {exam.Price}"));
}

Show();
