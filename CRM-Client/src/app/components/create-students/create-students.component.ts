import { Component } from '@angular/core';
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
  title: string = "Cadastrar medicamento";
  studentForm: FormGroup;
  schoolForm: FormGroup;
  responsibleForm: FormGroup;
  medicationForm: FormGroup;
  illnessForm: FormGroup;

  constructor(
    private fb: FormBuilder
  ) 
  {
    this.studentForm = this.fb.group({
      name: ['', Validators.required],
      cpf: [''],
      emergencePhone: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      address: ['', Validators.required],
      serie: ['', Validators.required],
      registerValue: ['', Validators.required],
      paymentDay: ['', Validators.required],
      schoolId: [''],
      responsibleId: ['']
    });

    this.schoolForm = this.fb.group({
      name: ['', Validators.required],
      phone: [''],
      address: ['']
    });

    this.responsibleForm = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required],
      type: ['', Validators.required],
      cpf: ['', Validators.required],
      address: ['', Validators.required],
      email: ['']
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
}
