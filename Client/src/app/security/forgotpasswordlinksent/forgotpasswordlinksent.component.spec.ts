import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForgotpasswordlinksentComponent } from './forgotpasswordlinksent.component';

describe('ForgotpasswordlinksentComponent', () => {
  let component: ForgotpasswordlinksentComponent;
  let fixture: ComponentFixture<ForgotpasswordlinksentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForgotpasswordlinksentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForgotpasswordlinksentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
