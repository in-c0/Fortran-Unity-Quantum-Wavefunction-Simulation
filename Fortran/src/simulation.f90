program schrodinger_1d
    implicit none
    integer, parameter :: dp = kind(1.0d0)
    integer, parameter :: n = 1000, steps = 500
    real(dp), parameter :: dx = 0.01_dp, dt = 0.0005_dp
    real(dp) :: psi_real(n), psi_imag(n), potential(n)
    integer :: i, j

    ! Initialize wavefunction (Gaussian wave packet)
    do i = 1, n
        psi_real(i) = exp(-((i - n/4)**2) * dx**2 / 0.1_dp)
        psi_imag(i) = 0.0_dp
        potential(i) = 0.0_dp
    end do

    ! Introduce a potential barrier in the middle
    do i = n/2 - 20, n/2 + 20
        potential(i) = 50.0_dp
    end do

    print *, "Starting time evolution..."

    ! Time evolution
    do j = 1, steps
        call time_step(psi_real, psi_imag, potential, n, dx, dt)
        print *, "Saving wavefunction at step ", j
        call save_wavefunction(psi_real, psi_imag, n, j)
    end do

    print *, "Simulation completed successfully."

end program schrodinger_1d

subroutine time_step(psi_real, psi_imag, potential, n, dx, dt)
    implicit none
    integer, parameter :: dp = kind(1.0d0)
    integer :: i, n
    real(dp), intent(inout) :: psi_real(n), psi_imag(n)
    real(dp), intent(in) :: potential(n), dx, dt
    real(dp), parameter :: hbar = 1.0_dp, m = 1.0_dp
    real(dp) :: psi_real_new(n), psi_imag_new(n)

    ! Update wavefunction using the Crank-Nicolson method
    do i = 2, n-1
        psi_real_new(i) = psi_real(i) - (dt / (2.0_dp * hbar * dx**2 / m)) * &
                          (psi_imag(i+1) - 2.0_dp * psi_imag(i) + psi_imag(i-1)) + &
                          dt / hbar * potential(i) * psi_imag(i)
        psi_imag_new(i) = psi_imag(i) + (dt / (2.0_dp * hbar * dx**2 / m)) * &
                          (psi_real(i+1) - 2.0_dp * psi_real(i) + psi_real(i-1)) - &
                          dt / hbar * potential(i) * psi_real(i)
    end do

    psi_real(2:n-1) = psi_real_new(2:n-1)
    psi_imag(2:n-1) = psi_imag_new(2:n-1)
end subroutine time_step
subroutine save_wavefunction(psi_real, psi_imag, n, step)
    implicit none
    integer, parameter :: dp = kind(1.0d0)
    integer :: i, n, step
    real(dp), intent(in) :: psi_real(n), psi_imag(n)
    character(len=200) :: filename_fortran, filename_unity

    ! Generate filenames for both directories
    write(filename_fortran, '("..//data//wavefunction_", i4.4, ".dat")') step
    write(filename_unity, '("../../Unity/Assets/Data/wavefunction_", i4.4, ".dat")') step

    ! Write to the Fortran/data directory
    print *, "Writing to file: ", filename_fortran
    open(unit=10, file=filename_fortran, status='replace', action='write')
    do i = 1, n
        write(10, '(I6, 2F12.6)') i, psi_real(i), psi_imag(i)
    end do
    close(10)

    ! Write to the Unity/Assets/Data directory
    print *, "Writing to file: ", filename_unity
    open(unit=11, file=filename_unity, status='replace', action='write')
    do i = 1, n
        write(11, '(I6, 2F12.6)') i, psi_real(i), psi_imag(i)
    end do
    close(11)
end subroutine save_wavefunction
