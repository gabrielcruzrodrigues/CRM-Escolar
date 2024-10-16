import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuComponent } from '../layout/menu/menu.component';
import { InfosBackComponent } from '../layout/infos-back/infos-back.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-students',
  standalone: true,
  imports: [MenuComponent, InfosBackComponent, ReactiveFormsModule],
  templateUrl: './create-students.component.html',
  styleUrl: './create-students.component.scss'
})
export class CreateStudentsComponent {
  link: string = '/students-panel';
  title: string = "Cadastrar estudante";
  studentForm: FormGroup;
  schoolForm: FormGroup;
  responsibleForm: FormGroup;
  medicationForm: FormGroup;
  illnessForm: FormGroup;
  step: number = 1;

  //----------------- divs id ------------------
  @ViewChild('student') student!: ElementRef;
  @ViewChild('responsible') responsible!: ElementRef;
  @ViewChild('school') school!: ElementRef;
  @ViewChild('medication') medication!: ElementRef;
  @ViewChild('illness') illness!: ElementRef;

  constructor(
    private fb: FormBuilder
  ) 
  {
    this.studentForm = this.fb.group({
      name: ['', Validators.required],
      cpf: [''],
      dateOfBirth: ['', Validators.required],
      address: ['', Validators.required],
      serie: ['', Validators.required],
      registerValue: ['', Validators.required],
      paymentDay: ['', Validators.required],
      emergencePhone: ['', Validators.required],
      schoolId: [''],
      responsibleId: [''],
      allergies: ['']
    });

    this.responsibleForm = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required],
      type: ['', Validators.required],
      cpf: ['', Validators.required],
      address: ['', Validators.required],
      email: ['']
    });

    this.schoolForm = this.fb.group({
      name: ['', Validators.required],
      phone: [''],
      address: ['']
    });


    this.medicationForm = this.fb.group({
      name: ['', Validators.required],
      times: ['', Validators.required],
      dosage: ['', Validators.required],
      studentId: ['', Validators.required]
    });

    this.illnessForm = this.fb.group({
      name: ['', Validators.required],
      observation: [''],
      studentId: ['', Validators.required]
    })
  }

  changeStep(option: string) : void
  {
    if (option === 'next' && this.step <= 4)
    {
      this.step++;
    }

    if (option === 'back' && this.step >= 2)
    {
      this.step--;
    }

    this.updateTemplate();
  }

  updateTemplate() : void
  {
    switch(this.step)
    {
      case 1: //Student
        this.title = "Cadastrar estudante";
        this.responsible.nativeElement.classList.add('disable');
        this.student.nativeElement.classList.remove('disable');
        break;

      case 2: //Responsible
        this.title = "Cadastrar responsável";
        this.student.nativeElement.classList.add('disable');
        this.responsible.nativeElement.classList.remove('disable');
        this.school.nativeElement.classList.add('disable');
        break;
        
      case 3: //School
        this.title = "Cadastrar escola";
        this.responsible.nativeElement.classList.add('disable');
        this.school.nativeElement.classList.remove('disable');
        this.medication.nativeElement.classList.add('disable');
        break;
        
      case 4: //Medication
        this.title = "Cadastrar medicação";
        this.school.nativeElement.classList.add('disable');
        this.medication.nativeElement.classList.remove('disable');
        this.illness.nativeElement.classList.add('disable');
        break;
        
      case 5: //Illness
        this.title = "Cadastrar enfermidade";
        this.medication.nativeElement.classList.add('disable');
        this.illness.nativeElement.classList.remove('disable');
        break;
    }
  }
}
