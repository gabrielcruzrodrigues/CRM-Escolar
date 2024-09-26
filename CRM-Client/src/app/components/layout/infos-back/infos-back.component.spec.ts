import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfosBackComponent } from './infos-back.component';

describe('InfosBackComponent', () => {
  let component: InfosBackComponent;
  let fixture: ComponentFixture<InfosBackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfosBackComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InfosBackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
