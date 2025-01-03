import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentsPanelComponent } from './students-panel.component';

describe('StudentsPanelComponent', () => {
  let component: StudentsPanelComponent;
  let fixture: ComponentFixture<StudentsPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentsPanelComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentsPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
