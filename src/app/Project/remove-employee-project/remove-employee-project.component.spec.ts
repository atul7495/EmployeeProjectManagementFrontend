import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveEmployeeProjectComponent } from './remove-employee-project.component';

describe('RemoveEmployeeProjectComponent', () => {
  let component: RemoveEmployeeProjectComponent;
  let fixture: ComponentFixture<RemoveEmployeeProjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveEmployeeProjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveEmployeeProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
