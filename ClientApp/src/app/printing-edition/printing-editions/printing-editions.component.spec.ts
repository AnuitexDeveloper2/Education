import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintingEditionsComponent } from './printing-editions.component';

describe('PrintingEditionsComponent', () => {
  let component: PrintingEditionsComponent;
  let fixture: ComponentFixture<PrintingEditionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintingEditionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintingEditionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
